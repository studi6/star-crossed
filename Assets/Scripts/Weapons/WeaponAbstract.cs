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
    public float recoil;
    public float shotVisibility;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected void fire()
    {
        // fire bullet (mouse1)
        if (Input.GetMouseButtonDown(0) && (currentClipAmmo > 0))
        {
            Debug.Log("firing...");
            GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity, ForceMode2D.Impulse);
            currentClipAmmo--;
        }
    }

    IEnumerator reloadWait() {
        yield return new WaitForSeconds(reloadTime);
        totalAmmo = totalAmmo - (maxClipAmmo - currentClipAmmo);
        currentClipAmmo = maxClipAmmo;
        Debug.Log("reloaded");
    }

    protected void reload()
    {
        // reload weapon (r)
        if (Input.GetKeyDown("r") && (currentClipAmmo < maxClipAmmo))
        {
            Debug.Log("reloading...");
            StartCoroutine(reloadWait());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
