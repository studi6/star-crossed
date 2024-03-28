using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 initialPosition;

    [SerializeField]
    private float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        maxDistance = 100f; // placeholder value
    }

    void Update()
    {
        // remove bullet when too far from initial position
        float distance = Vector3.Distance(initialPosition, transform.position);
        if (distance >= maxDistance)
        {
            //Destroy(gameObject); 
        }
    }
}
