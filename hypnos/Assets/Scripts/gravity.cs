using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rb;

    public float speed;

    Vector3 direction;

    public GameObject falling;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = falling.transform.position;
        //Debug.Log(direction);
        //rb.AddForce(direction * speed, ForceMode.VelocityChange);
        transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * speed);
    }
}
