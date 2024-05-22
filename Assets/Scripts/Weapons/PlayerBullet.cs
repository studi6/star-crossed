using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletScript
{
    [SerializeField]
    private int damage;
     void Start()
    {
        damage = 1; // placeholder value
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
