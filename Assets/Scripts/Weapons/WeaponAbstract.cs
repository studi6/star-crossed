using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAbstract : MonoBehaviour
{
    public GameObject bullet;
    public int currentClipAmmo;
    public int clipAmmo;
    public int totalAmmo;
    public float bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected void fireBullet()
    {
        // fire bullet (mouse1)
        if (Input.GetMouseButtonDown(0) && (currentClipAmmo > 0))
        {
            GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity, ForceMode2D.Impulse);
            currentClipAmmo--;
        }
    }

    protected void reloadBullet()
    {
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
    }
}
