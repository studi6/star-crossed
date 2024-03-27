using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField]
    private float heal;
    // Start is called before the first frame update
    void Start()
    {
        heal = 10f; // placeholder amount
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) // currently only Player has health
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.ReplenishHealth(heal); // call function in HealthSystem.cs
            }
        }
    }
}
