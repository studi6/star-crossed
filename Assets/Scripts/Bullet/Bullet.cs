using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 10f; // placeholder value
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // currently only Player has health
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.TakeDamage(damage); // call function in HealthSystem.cs
            }
        }
    }
}
