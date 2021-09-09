using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float fallMarkiplier = 2.5f;
    public float lowJumpMarkiplier = 2f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(rb.velocity.y<0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMarkiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y>0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMarkiplier - 1) * Time.deltaTime;
        }
    }

}
