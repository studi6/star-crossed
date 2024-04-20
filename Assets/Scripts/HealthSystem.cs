using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    protected float health;
    [SerializeField]
    protected const float MAXHEALTH = 100f;
    [SerializeField] bool isBoss = false;
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
            if (isBoss)
            {
                // Subtract health from boss health bar
                SystemManager.instance.AddHealth(damage);
                // Camera shake effect when boss is hit
                SystemManager.instance.DoCameraShake(0.09f, 0.09f);
            }
            if (health <= 0f)
            {
                Debug.Log("Entity is dead"); // console log check
                if (gameObject.CompareTag("Enemy"))
                {
                    if (isBoss)
                        SystemManager.instance.ChangeGameState(0);
                    Destroy(gameObject);
                }
            }
        }
    }

    public void ReplenishHealth(float heal)
    {
        if (health < MAXHEALTH)
        {
            health += heal; // heal amount depend on HealItem script
            if (health > MAXHEALTH)
                health = MAXHEALTH;
            Debug.Log("Entity Health: " + health); // console log check
        }
        else
        {
            Debug.Log("Entity at max health"); // console log check
        }
    }

    public float getMaxHealth()
    {
        return MAXHEALTH;
    }

    public float getHealth()
    {
        return health;
    }
}
