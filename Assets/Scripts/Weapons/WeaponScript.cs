using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Weapon contains type of bullet, and ammo count, and any other weapon specific assets.
// TODO: make weapon into an abstract class

public class WeaponScript : MonoBehaviour
{
    public GameObject bullet;
    public int currentClipAmmo;
    public int clipAmmo;
    public int totalAmmo;
    public float bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        clipAmmo = 10;
        totalAmmo = 100;
        currentClipAmmo = clipAmmo;
        bulletVelocity = 20;
    }

    private void fireBullet() 
    {
        // fire bullet (mouse1)
        if (Input.GetMouseButtonDown(0) && (currentClipAmmo > 0))
        {
            GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity, ForceMode2D.Impulse);
            currentClipAmmo--;
        }

        // reload weapon (r)
        if (Input.GetKey("r"))
        {
            totalAmmo = totalAmmo - (clipAmmo - currentClipAmmo);
            currentClipAmmo = clipAmmo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fireBullet();
    }
}
