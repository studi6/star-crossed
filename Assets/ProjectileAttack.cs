using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public void RangedAttack(GameObject bullet, Transform transform, Vector3 position, float speed, string enemyTag)
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Projectile>().MoveToTarget(position, speed);
    }

    private void OnTriggerEnter2D(Collider2D other) //disappear on hit
    {
        if (other.gameObject.tag == enemyTag)
            other.GetComponent<Health>().TakeDamage(1);
        if (other.gameObject.tag == "Weapon")
            GetComponent<Health>().TakeDamage(1);
    }
}
