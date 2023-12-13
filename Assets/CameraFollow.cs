using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        var newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos,followSpeed*Time.deltaTime);
    }
}
