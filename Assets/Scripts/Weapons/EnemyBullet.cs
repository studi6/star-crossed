using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletScript
{
    [SerializeField]
    private int damage;
     void Start()
    {
        damage = 10; // placeholder value
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.TakeDamage(damage); // call function in HealthSystem.cs
                Destroy(gameObject);
            }
        }
    }
}