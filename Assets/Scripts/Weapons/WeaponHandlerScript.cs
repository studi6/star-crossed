using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandlerScript : MonoBehaviour
{
    private Transform m_transform;
    private SpriteRenderer sr;
    private Sprite sprite;
    [SerializeField] private Weapon gun1;
    [SerializeField] private Weapon gun2;
    private Weapon melee;
    private Weapon cur_weapon;

    public GameObject item;
    public GameObject bullet;
    public AudioSource audioSource;
    public bool isActive;
    private bool canFire = true;

    // checks the angle of the mouse, then rotates object
    private void rotateWeapon()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        m_transform.rotation = rotation;
    }

    private void setCurWeapon(Weapon wep)
    {
        cur_weapon = wep;
        m_transform = cur_weapon.transform;
        sprite = cur_weapon.sprite;
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
  
    // Start is called before the first frame update
    void Start()
    {
        setCurWeapon(gun1);
    }

    // Update is called once per frame
    void Update()
    {
        rotateWeapon();
        swapWeapon();
    }
}
