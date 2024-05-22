using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float m_fHealth { get; private set; }
    [SerializeField]
    public const float MAXHEALTH = 100f;
    [SerializeField] bool isBoss = false;
    // Start is called before the first frame update
    
    void Start()
    {
        // Set localPlayer's health to max health
        m_fHealth = MAXHEALTH;
    }

    public void TakeDamage(float damage)
    {
        if (m_fHealth > 0f)
        {
            m_fHealth -= damage; // damage amount depend on Bullet script
            Debug.Log("Entity Health: " + m_fHealth); // console log check
            if (isBoss)
            {
                // Subtract health from boss health bar
                SystemManager.instance.DamageBossHealthBar(damage);
                // Camera shake effect when boss is hit
                SystemManager.instance.DoCameraShake(0.09f, 0.09f);
                // Health bar shake effect when boss is hit
                SystemManager.instance.DoHealthBarShake(0.1f, 0.06f);
            }
            if (m_fHealth <= 0f)
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
        if (m_fHealth < MAXHEALTH)
        {
            m_fHealth += heal; // heal amount depend on HealItem script
            if (m_fHealth > MAXHEALTH)
                m_fHealth = MAXHEALTH;
            Debug.Log("Entity Health: " + m_fHealth); // console log check
        }
        else
        {
            Debug.Log("Entity at max health"); // console log check
        }
    }
}
