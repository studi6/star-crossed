using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletScript
{
    public float damage;
     void Start()
    {
        damage = 0.015f; // placeholder value
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.TakeDamage(damage); // call function in HealthSystem.cs
                Destroy(gameObject);
            }
        }
    }
}
