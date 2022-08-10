using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    public Transform cam;
    private void Start()
    {
        cam = GameManager.instance.cam;

    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
