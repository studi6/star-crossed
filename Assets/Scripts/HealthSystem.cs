using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float health;
    [SerializeField]
    private const float MAXHEALTH = 100f;
    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH;  
    }

    public void TakeDamage(float damage)
    {
        if (health > 0f) 
        {
            health -= damage; // damage amount depend on Bullet script
            Debug.Log("Entity Health: " + health); // console log check
        } else {
            Debug.Log("Entity is dead"); // console log check
        } 
    }

    public void ReplenishHealth(float heal)
    {
        if (health < MAXHEALTH) {
            health += heal; // heal amount depend on HealItem script
            if (health> MAXHEALTH)
                health= MAXHEALTH;
            Debug.Log("Entity Health: " + health); // console log check
        } else {
            Debug.Log("Entity at max health"); // console log check
        }
    }
}
