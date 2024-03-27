using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandlerScript : MonoBehaviour
{
    private Transform m_transform;
    private SpriteRenderer childSprite;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject melee;
    public GameObject item;
    public GameObject cur_weapon;

    // checks the angle of the mouse, then rotates object
    private void rotateWeapon()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        m_transform.rotation = rotation;
    }

    private void setCurWeapon(GameObject wep)
    {
        cur_weapon = wep;
        m_transform = cur_weapon.transform;
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
        cur_weapon.gameObject.SetActive(true);
        childSprite = cur_weapon.gameObject.GetComponent<SpriteRenderer>();
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
        gun1 = this.transform.GetChild(0).gameObject;
        gun2 = this.transform.GetChild(1).gameObject;
        setCurWeapon(gun1);
    }

    // Update is called once per frame
    void Update()
    {
        rotateWeapon();
        swapWeapon();
    }
}
