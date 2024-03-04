using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Weapon contains type of bullet, and ammo count, and any other weapon specific assets.
// TODO: make weapon into an abstract class

public class WeaponScript : WeaponAbstract
{
    // Start is called before the first frame update
    void Start()
    {
        maxClipAmmo = 10;
        totalAmmo = 100;
        currentClipAmmo = maxClipAmmo;
        bulletVelocity = 20;
        reloadTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        fire();
        reload();
    }
}
