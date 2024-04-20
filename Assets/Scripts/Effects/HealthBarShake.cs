using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarShake : MonoBehaviour
{
    // Make it a singleton
    #region Singleton
    public static HealthBarShake instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion


    // Camera shake effect when boss is hit.
    // Default values:
    // duration = 0.1f
    // magnitude = 0.06f
    public IEnumerator Shake(GameObject healthBar, float duration, float magnitude)
    {
        Vector3 originalPosition = healthBar.transform.position;
        Vector3 originalScale = healthBar.transform.localScale;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            healthBar.transform.position = originalPosition + new Vector3(x, y, 0f);
            healthBar.transform.localScale = originalScale + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;

            yield return null;
        }

        healthBar.transform.position = originalPosition;
        healthBar.transform.localScale = originalScale;
    }
}
