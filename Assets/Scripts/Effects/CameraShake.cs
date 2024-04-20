using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Make it singleton
    #region Singleton
    public static CameraShake instance;
    private void Awake()
    {
        if (instance == null)
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

            cameraObject.transform.localPosition = new UnityEngine.Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraObject.transform.localPosition = originalPos;
    }
}
