using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTest : MonoBehaviour
{
    public CameraShake cameraShake; // Add a reference to the CameraShake object

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
    }
}
