using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Make it singleton
    #region Singleton
    public static CameraShake instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    public IEnumerator Shake(Camera cameraObject, float duration, float magnitude)
    {
        UnityEngine.Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Smoothly interpolate between the current position and the target position
            UnityEngine.Vector3 targetPos = originalPos + new UnityEngine.Vector3(x, y, 0f);
            cameraObject.transform.localPosition = UnityEngine.Vector3.Lerp(cameraObject.transform.localPosition, targetPos, Time.deltaTime * 10f);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraObject.transform.localPosition = originalPos;
    }
}
