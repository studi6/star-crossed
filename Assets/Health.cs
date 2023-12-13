using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int health;
    [SerializeField] float immunityDuration = 0.5f;
    bool canTakeDamage = true;
    
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            StartCoroutine(StartIframes());
            health-=damage;
            if (health <=0)
                Destroy(gameObject);
        }
    }

    private IEnumerator StartIframes()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(immunityDuration);
        canTakeDamage = true;
    }

}

