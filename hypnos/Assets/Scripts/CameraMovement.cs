using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;

    public float Y;
    public float Z;

    public float scrollStipris;

    
    void Start()
    {
        
    }


    void Update()
    {
        Z += Input.mouseScrollDelta.y * scrollStipris;
    }

    void FixedUpdate()
    {
        Vector3 coords = player.transform.position;
        transform.position = coords + new Vector3(0.0f, Y, Z);
    }
}
