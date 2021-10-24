using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class playerRotation : MonoBehaviour
{

    [HideInInspector]
    public changeGravity ChangeGravity;
    public Transform playerCam;

    private Quaternion desiredRotation;
    private float rotationSpeed = 10000f;

    void Start()
    {
        ChangeGravity = GetComponent<changeGravity>();    
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        //playerCam.transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }

    public void setRotation(Vector3 a)
    {
        float x = -1 * (a.y * a.x) / (float)Math.Sqrt(a.x * a.x + a.z * a.z);
        float y = (float)Math.Sqrt(a.x * a.x + a.z * a.z);
        float z = -1 * (a.y * a.z) / (float)Math.Sqrt(a.x * a.x + a.z * a.z);


        Vector3 b = new Vector3(x, y, z);


        desiredRotation = Quaternion.LookRotation(b);
    }
}
