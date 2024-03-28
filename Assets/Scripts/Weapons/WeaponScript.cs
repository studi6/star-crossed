using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : WeaponAbstract
{
    // Start is called before the first frame update
    void Start()
    {
        maxClipAmmo = 10;
        totalAmmo = 100;
        fireRate = 0.2f;
        currentClipAmmo = maxClipAmmo;
        bulletVelocity = 20;
        reloadTime = 1;
    }
}
