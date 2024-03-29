using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarter : MonoBehaviour
{
    public GameObject bullet;

    public float bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        bulletVelocity = 10f;
        StartCoroutine(Firing()); 
    }

    IEnumerator Firing() {
        while (true) {
            yield return new WaitForSeconds(2); // Wait for 2 seconds
            fire(); // Fire bullet
        }
    }


    protected void fire()
    {
        Vector3 offset = transform.right * 1f;
        // borrowed from the WeaponAbstract script
        GameObject projectile = Instantiate(bullet, transform.position + offset, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity, ForceMode2D.Impulse);
    }
}
