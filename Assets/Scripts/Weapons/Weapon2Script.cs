using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Script : WeaponAbstract
{
    // Start is called before the first frame update
    void Start()
    {
        maxClipAmmo = 5;
        totalAmmo = 50;
        currentClipAmmo = maxClipAmmo;
        bulletVelocity = 50;
        reloadTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        fire();
        reload();
    }
}
