using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float height = 20.0f;
    public float distance = 15.0f;

    void Update()
    {
        //transform.LookAt(target.position);
        transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z+distance);
    }
}
