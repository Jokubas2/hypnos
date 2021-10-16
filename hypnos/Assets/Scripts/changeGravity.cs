using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class changeGravity : MonoBehaviour
{

    float maxDistance = 100f;
    private Vector3 gravityPoint;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform daCamera;

    [HideInInspector]
    public Vector3 gravityDirection = new Vector3(0f, -1f, 0f);

    private playerMovement PlayerMovement;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            setGravity();
        }
    }

    void setGravity()
    {
        RaycastHit hit;
        if (Physics.Raycast(daCamera.position, daCamera.forward, out hit, maxDistance, whatIsGround))
        {
            gravityPoint = hit.point;


            gravityDirection = gravityPoint - transform.position;

            double f = Math.Sqrt(gravityDirection.x * gravityDirection.x + gravityDirection.y * gravityDirection.y + gravityDirection.z * gravityDirection.z);
            gravityDirection.x /= (float)f;
            gravityDirection.y /= (float)f;
            gravityDirection.z /= (float)f;
            gravityDirection *= 20;

            Debug.Log(gravityDirection);

            Physics.gravity = gravityDirection;

            PlayerMovement.gDirection = gravityDirection;

            
        }
    }

    


}
