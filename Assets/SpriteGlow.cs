using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpriteGlow : MonoBehaviour
{
    public Light2D light2D;
    public float minIntensity = 0f;
    public float maxIntensity = 12f;
    public float lerpDuration = 0.5f;
    private bool isGrowing = true;
    private float timer = 0f;
    private float startIntensity;
    private float endIntensity;

    private void Start()
    {
        // Set initial intensity based on isGrowing state
        SetIntensity();

        // Start the lerp coroutine
        StartCoroutine(LerpIntensity());
    }

    private void Update()
    {
        // Update timer only when lerping
        if (timer < lerpDuration)
        {
            timer += Time.deltaTime;
        }
    }

    private void SetIntensity()
    {
        startIntensity = isGrowing ? minIntensity : maxIntensity;
        endIntensity = isGrowing ? maxIntensity : minIntensity;
        light2D.intensity = startIntensity;
    }

    private IEnumerator LerpIntensity()
    {
        while (true)
        {
            // Check if lerping is needed
            if (timer < lerpDuration)
            {
                float lerpProgress = timer / lerpDuration;
                float lerpedIntensity = Mathf.Lerp(startIntensity, endIntensity, lerpProgress);
                light2D.intensity = lerpedIntensity;
            }
            else
            {
                // Lerp completed, toggle isGrowing and reset timer
                isGrowing = !isGrowing;
                SetIntensity();
                timer = 0f;
            }

            // Wait for the next frame
            yield return null;
        }
    }
}
