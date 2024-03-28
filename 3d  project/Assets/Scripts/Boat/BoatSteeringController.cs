using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSteeringController : MonoBehaviour
{
    [Header("Steering Power")]
    public float turnSpeed = 1000f;
    public float accellerateSpeed = 1000f;

    [Header("RigidBody")]
    public Rigidbody boatRB;

    private void Start()
    {
        boatRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        boatRB.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        boatRB.AddForce(transform.forward * v * accellerateSpeed * Time.deltaTime);
    }

}
