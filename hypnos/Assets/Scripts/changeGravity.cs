using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class changeGravity : MonoBehaviour
{

    private float maxDistance = 10000f;
    [HideInInspector]
    public Vector3 gravityPoint;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform daCamera;

    [SerializeField]
    private GameObject firstGravity;

    private Vector3 gravityDirection = new Vector3(0f, -20f, 0f);
    [HideInInspector]
    public Vector3 gDirection = new Vector3(0f, -1f, 0f);
    public float gravityStrength = 20f;

    [HideInInspector]
    public playerRotation PlayerRotation;
    [HideInInspector]
    public playerMovement PlayerMovement;


    private LineRenderer lr;

    private bool isCenter = false;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        PlayerRotation = GetComponent<playerRotation>();
        PlayerMovement = GetComponent<playerMovement>();


        //set gravity
        lr.positionCount = 2;

        gravityPoint = firstGravity.transform.position;
        updateGravity();
        isCenter = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            setGravity();
            PlayerRotation.setRotation(gravityDirection);
            PlayerMovement.setRotation(gravityDirection);
        }

        if(isCenter)
        {
            updateGravity();
            PlayerRotation.setRotation(gravityDirection);
            PlayerMovement.setRotation(gravityDirection);
        }
    }

    void LateUpdate() {

        if (isCenter)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, gravityPoint);
        } else
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, (transform.position + gravityDirection));
        }

    }

    void setGravity()
    {

        RaycastHit hit;
        if (Physics.Raycast(daCamera.position, daCamera.forward, out hit, maxDistance, whatIsGround))
        {
            gravityPoint = hit.point;

            lr.positionCount = 2;

            if (hit.collider.tag=="GravityCenter")
            {
                gravityPoint = hit.collider.transform.position;
                updateGravity();
                isCenter = true;
            }
            else
            {

                updateGravity();
                isCenter = false;

            }

        }
    }

    void updateGravity()
    {
        gravityDirection = gravityPoint - transform.position;

        double f = Math.Sqrt(gravityDirection.x * gravityDirection.x + gravityDirection.y * gravityDirection.y + gravityDirection.z * gravityDirection.z);
        gravityDirection.x /= (float)f;
        gravityDirection.y /= (float)f;
        gravityDirection.z /= (float)f;

        float x = gravityDirection.x;
        float y = gravityDirection.y;
        float z = gravityDirection.z;

        /*if((x==0&&(x==y||x==z))||(y==0&&y==z))
        {
            lr.positionCount = 0;
        }*/

        gDirection = gravityDirection;
        gravityDirection *= gravityStrength;

        Physics.gravity = gravityDirection;

        //PlayerMovement.gDirection = gDirection;

        PlayerRotation.setRotation(gravityDirection);
        PlayerMovement.setRotation(gravityDirection);
        //PlayerRotation.setRotation(gravityPoint);
    }

}
