using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAbstract : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource audioSource;
    public AudioClip gunShootSound;
    public AudioClip gunReloadtSound;
    public float gunReloadtSoundVolume = 0.15F; // Volume Control for the reload sound (my ears are bleeding bro help)
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
        if (Input.GetMouseButton(0) && canFire && (currentClipAmmo > 0))
        {
            audioSource.Stop();
            Fire();
        }
        if (Input.GetKeyDown("r") && (currentClipAmmo < maxClipAmmo))
        {
            Reload();
        }
        if (currentClipAmmo == 0)
        {
            Reload();
        }

    }

    protected void Fire()
    {
        audioSource.PlayOneShot(gunShootSound);
        GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity, ForceMode2D.Impulse);
        currentClipAmmo--;
        StartCoroutine(FireRateCooldown());
    }

    IEnumerator FireRateCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    private void Reload()
    {
        StartCoroutine(ReloadWait());
        audioSource.PlayOneShot(gunReloadtSound, gunReloadtSoundVolume);
    }

    IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(reloadTime);
        totalAmmo = totalAmmo - (maxClipAmmo - currentClipAmmo);
        currentClipAmmo = maxClipAmmo;
    }
}
