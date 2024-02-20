using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAbsract : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    protected int currentClipAmmo;
    protected int clipAmmo;
    protected int totalAmmo;

    // Start is called before the first frame update
    void Start()
    {
        currentClipAmmo = clipAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        // fire bullet
        if (Input.GetMouseButtonDown(0) && (currentClipAmmo > 0)) {
            Instantiate(bullet, transform.parent.position, transform.parent.rotation);
            currentClipAmmo--;
        }

        // reload weapon "r"
        if (Input.GetKey("r")) {
            totalAmmo = totalAmmo - (clipAmmo - currentClipAmmo);
            currentClipAmmo = clipAmmo;
        }
    }
}
