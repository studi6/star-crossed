using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float fHealth { get; private set; }
    [SerializeField]
    protected const float MAXHEALTH = 100f;
    [SerializeField] bool isBoss = false;
    // Start is called before the first frame update
    
    void Start()
    {
        // Set localPlayer's health to max health
        fHealth = MAXHEALTH;
    }

    public void TakeDamage(float damage)
    {
        if (fHealth > 0f)
        {
            fHealth -= damage; // damage amount depend on Bullet script
            Debug.Log("Entity Health: " + fHealth); // console log check
            if (isBoss)
            {
                // Subtract health from boss health bar
                SystemManager.instance.AddHealth(damage);
                // Camera shake effect when boss is hit
                SystemManager.instance.DoCameraShake(0.09f, 0.09f);
                // Health bar shake effect when boss is hit
                SystemManager.instance.DoHealthBarShake(0.1f, 0.06f);
            }
            if (fHealth <= 0f)
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
        if (fHealth < MAXHEALTH)
        {
            fHealth += heal; // heal amount depend on HealItem script
            if (fHealth > MAXHEALTH)
                fHealth = MAXHEALTH;
            Debug.Log("Entity Health: " + fHealth); // console log check
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
}
