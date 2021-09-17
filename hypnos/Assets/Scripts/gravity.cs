using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    public float rotationSpeed = 10.0f;

    Vector3 direction;

    public GameObject destination;  

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = destination.transform.position;

        Vector3 offset;
        float magsqr;   
        offset = direction - transform.position;



        magsqr = offset.sqrMagnitude;

        if (magsqr > 0.0001f)
        {
            rb.AddForce((speed * offset.normalized / magsqr) * rb.mass);   
        }
    }


    //rotate towards gravity;
    void Update()
    {
        /*Vector3 targetDirection = -1*destination.transform.position - transform.position;

        float singleStep = rotationSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
        */
        
    }
}
