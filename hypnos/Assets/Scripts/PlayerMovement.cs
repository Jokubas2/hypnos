using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 jump;

    public float jumpForgive = 0.5f;
    public float jumpTime = 0.5f;

    float jumpForgiveness;
    float jumpLength;

    public float jumpForce = 4.0f;
    public float movementSpeed = 2.0f;

    public bool isGrounded;



    GameObject lastCollider;
    GameObject currentCollider;

    int jumpDelay = 0;
    int jumpTimer = 0;
    

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        jumpForgiveness = jumpForgive;
        jumpLength = jumpTime;
        jumpForgiveness *= 50;
        jumpLength *= 50;

        //Physics.gravity = new Vector3(0, -9.83f, 0);
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        currentCollider = collision.gameObject;
    }
    void OnCollisionExit()
{
        isGrounded = false;
    }


    int x = 1, y = 0, z = 0;

    private void FixedUpdate()
    {
        if(jumpDelay>=0)
        jumpDelay--;
        if(jumpTimer>=0)
        jumpTimer--;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpDelay = (int)jumpForgiveness;
        }

        if (jumpDelay > 0 && isGrounded )
        {
            if((currentCollider==lastCollider && jumpTimer < 0)||currentCollider!=lastCollider)
            {
                lastCollider = currentCollider;
                jumpDelay = -1;
                jumpTimer = (int)jumpLength;
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            
        }


        if (Input.GetKey(KeyCode.D))
        {
            Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);
            rb.AddForce(direction * movementSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 direction = new Vector3(-1.0f, 0.0f, 0.0f);
            rb.AddForce(direction * movementSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);
            rb.AddForce(direction * movementSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 direction = new Vector3(0.0f, 0.0f, -1.0f);
            rb.AddForce(direction * movementSpeed, ForceMode.Acceleration);
        }
    }



    
}
