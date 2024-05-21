using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Weapon/New Weapon")]
public class Weapon : ScriptableObject
{
    new public string name = "New Weapon";
    public Sprite sprite = null;
    public Sprite bulletSprite = null;
    public AudioClip gunShootSound;
    public AudioClip gunReloadSound;
    public float gunReloadSoundVolume = 0.15F; // Volume Control for the reload sound (my ears are bleeding bro help)
    public float damage;
    public int maxClipAmmo;
    public int totalAmmo;
    public int currentClipAmmo;
    public float bulletVelocity;
    public float reloadTime;
    public float fireRate;
    public float recoil;
    public float shotVisibility;
}
