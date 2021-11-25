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

    [HideInInspector]
    public playerMovement PlayerMovement;

    public FauxGravityAttractor attractor;
    private RaycastHit hit;

    private void Start()
    {
        attractor = firstGravity.GetComponent<FauxGravityAttractor>();
        PlayerMovement = GetComponent<playerMovement>();
    }

    private void Update()
    {
        attractor.Attract(GetComponent<Transform>());

        if (Input.GetMouseButtonDown(0))
        {
            setGravity();
        }
    }

    private void setGravity()
    {
        if (Physics.Raycast(daCamera.position, daCamera.forward, out hit, maxDistance, whatIsGround))
        {
            if (hit.collider.tag == "GravityCenter")
            {
                attractor = hit.collider.GetComponent<FauxGravityAttractor>();
            }
        }
    }
}