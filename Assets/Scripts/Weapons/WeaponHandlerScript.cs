using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandlerScript : MonoBehaviour
{
    private Transform transform;
    private AudioSource audioSource;
    private SpriteRenderer sr;
    [SerializeField] private Weapon gun1;
    [SerializeField] private Weapon gun2;
    public Weapon melee;
    public Weapon cur_weapon;
    public int currentClipAmmo;

    public GameObject item;
    public GameObject bullet;
    
    public bool canFire = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        setCurWeapon(gun1);
    }

    private void rotateWeapon()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    private void setCurWeapon(Weapon wep)
    {
        cur_weapon = wep;
        currentClipAmmo = cur_weapon.currentClipAmmo;
        sr.sprite = cur_weapon.sprite;
    }

    private void swapWeapon()
    {
        if (Input.GetKeyDown("1"))
        {
            setCurWeapon(gun1);
        }
        if (Input.GetKeyDown("2"))
        {
            setCurWeapon(gun2);
        }
    }

    private void Fire()
    {
        audioSource.PlayOneShot(cur_weapon.gunShootSound);
        GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * cur_weapon.bulletVelocity, ForceMode2D.Impulse);
        projectile.GetComponent<PlayerBullet>().damage = cur_weapon.damage;
        currentClipAmmo--;
        StartCoroutine(FireRateCooldown());
    }

    IEnumerator FireRateCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cur_weapon.fireRate);
        canFire = true;
    }

    private void Reload()
    {
        StartCoroutine(ReloadWait());
        audioSource.PlayOneShot(cur_weapon.gunReloadSound, cur_weapon.gunReloadSoundVolume);
    }

    IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(cur_weapon.reloadTime);
        cur_weapon.totalAmmo = cur_weapon.totalAmmo - (cur_weapon.maxClipAmmo - currentClipAmmo);
        currentClipAmmo = cur_weapon.maxClipAmmo;
    }

    private void Update()
    {
        rotateWeapon();
        swapWeapon();
        if (Input.GetMouseButton(0) && canFire && (currentClipAmmo > 0))
        {
            audioSource.Stop();
            Fire();
        }
        if (Input.GetKeyDown("r") && (currentClipAmmo < cur_weapon.maxClipAmmo))
        {
            Reload();
        }
        if (currentClipAmmo == 0)
        {
            Reload();
        }
    }
    // checks the angle of the mouse, then rotates object
}
