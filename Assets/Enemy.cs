using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int attackDamage = 1;

    private void OnTriggerStay2D(Collider2D other) //disappear on hit
    {
        if (other.gameObject.tag == "Player")
            other.GetComponent<Health>().TakeDamage(attackDamage);
        if (other.gameObject.tag == "Weapon")
            GetComponent<Health>().TakeDamage(1);
    }
}
