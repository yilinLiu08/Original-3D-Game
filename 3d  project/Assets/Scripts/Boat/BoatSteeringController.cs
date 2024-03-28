using Ditzelgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ditzelgames;

public class BoatSteeringController : MonoBehaviour
{

    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    protected Rigidbody rb;
    protected Quaternion StartRotation;

    [SerializeField] BoxCollider playerDetection;
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
        playerDetection = GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //default direction
        var forceDirection = transform.forward;
        var steer = 0;

        //steer direction
        if (Input.GetKey(KeyCode.A))
        {
            steer = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            steer = -1;
        }

        //rotational force
        rb.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);

        //compute vectors
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        var targetVel = Vector3.zero;

        //forward/backward power
        if (Input.GetKey(KeyCode.W))
        {
            PhysicsHelper.ApplyForceToReachVelocity(rb, forward * MaxSpeed, Power);
        }
        if (Input.GetKey(KeyCode.S))
        {
            PhysicsHelper.ApplyForceToReachVelocity(rb, forward * -MaxSpeed, Power);
        }
    }
}
