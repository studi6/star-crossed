using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int m_iHealth { get; private set; }
    [SerializeField]
    public const int MAXHEALTH = 100;
    [SerializeField] bool isBoss = false;
    // Start is called before the first frame update
    
    void Start()
    {
        // Set localPlayer's health to max health
        m_iHealth = MAXHEALTH;
    }

    public void TakeDamage(int damage)
    {
        if (m_iHealth > 0f)
        {
            m_iHealth -= damage; // damage amount depend on Bullet script
            Debug.Log("Entity Health: " + m_iHealth); // console log check
            if (isBoss)
            {
                // Subtract health from boss health bar
                SystemManager.instance.DamageBossHealthBar(damage);
                // Camera shake effect when boss is hit
                SystemManager.instance.DoCameraShake(0.09f, 0.09f);
                // Health bar shake effect when boss is hit
                SystemManager.instance.DoHealthBarShake(0.1f, 0.06f);
            }
            if (m_iHealth <= 0f)
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

    public void ReplenishHealth(int heal)
    {
        if (m_iHealth < MAXHEALTH)
        {
            m_iHealth += heal; // heal amount depend on HealItem script
            if (m_iHealth > MAXHEALTH)
                m_iHealth = MAXHEALTH;
            Debug.Log("Entity Health: " + m_iHealth); // console log check
        }
        else
        {
            Debug.Log("Entity at max health"); // console log check
        }
    }
}
