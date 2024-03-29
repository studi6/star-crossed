using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            Destroy(gameObject);
        }
    }
}
