using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField]
    private int heal;
    // Start is called before the first frame update
    void Start()
    {
        heal = 10; // placeholder amount
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) // currently only Player has health
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.ReplenishHealth(heal); // call function in HealthSystem.cs
                Debug.Log("Entity should gain health"); // console check
            }
        }
    }
}
