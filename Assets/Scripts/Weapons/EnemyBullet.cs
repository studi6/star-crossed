using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletScript
{
    [SerializeField]
    private float damage;
     void Start()
    {
        damage = 10f; // placeholder value
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit the player");
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.TakeDamage(damage); // call function in HealthSystem.cs
                Destroy(gameObject);
            }
        }
    }
}