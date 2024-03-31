using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAbstract : MonoBehaviour
{
    public GameObject bullet;
    public int currentClipAmmo;
    public int maxClipAmmo;
    public int totalAmmo;
    public float bulletVelocity;
    public float reloadTime;
    public float fireRate;
    public float recoil;
    public float shotVisibility;
    public bool active;

    private bool canFire = true;  

    void Update()
    {
        if (Input.GetMouseButton(0) && canFire && (currentClipAmmo > 0)){
            Fire();
        }
        if (Input.GetKeyDown("r") && (currentClipAmmo < maxClipAmmo)){
            StartCoroutine(ReloadWait());
        }
        if (currentClipAmmo==0)
            StartCoroutine(ReloadWait());
    }  

    protected void Fire()
    {
        GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity, ForceMode2D.Impulse);
        currentClipAmmo--;
        StartCoroutine(FireRateCooldown()); 
    }

    IEnumerator FireRateCooldown(){
        canFire = false; 
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    IEnumerator ReloadWait() {
        yield return new WaitForSeconds(reloadTime);
        totalAmmo = totalAmmo - (maxClipAmmo - currentClipAmmo);
        currentClipAmmo = maxClipAmmo;
    }
}
