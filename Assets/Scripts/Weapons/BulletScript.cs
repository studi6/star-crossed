using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    public string tag;
    public string enemyTag;
    public Rigidbody2D rb;
    private float timer = 0f;

    private void Start(){
        if (tag == "Player"){
            enemyTag = "Enemy";
        }
        else{
            enemyTag = "Player";
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.TakeDamage(damage); // call function in HealthSystem.cs
            }
            Destroy(gameObject);
        }
    }
}
