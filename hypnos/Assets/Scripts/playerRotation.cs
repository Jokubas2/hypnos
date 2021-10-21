using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class playerRotation : MonoBehaviour
{

    [HideInInspector]
    public changeGravity ChangeGravity;

    private Quaternion desiredRotation;
    private float rotationSpeed = 10000f;

    void Start()
    {
        ChangeGravity = GetComponent<changeGravity>();    
    }

    void Update()
    {
        //desiredRotation = Quaternion.LookRotation(ChangeGravity.getGravityPoint() - transform.position);


        //transform.rotation = Quaternion.Inverse(desiredRotation);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);


        /*Vector3 targetPoint = ChangeGravity.getGravityPoint();
        Debug.Log(targetPoint);

        Vector3 targetDirection = targetPoint - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);*/
    }

    public void setRotation(Vector3 a)
    {
        a -= transform.position;

        float x = a.y / (float)Math.Sqrt(a.x * a.x + a.z * a.z) * a.x * -1;
        float y = (float)Math.Sqrt(a.x * a.x + a.z * a.z);
        float z = a.y / (float)Math.Sqrt(a.x * a.x + a.z * a.z) * a.z * -1;


        Vector3 b = new Vector3(x, y, z);


        desiredRotation = Quaternion.LookRotation(b);
    }
}
