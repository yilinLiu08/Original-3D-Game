using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyController : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underwaterAngularDrag = 1f;

    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 0f;

    Rigidbody objectRigidBody;

    bool underwater;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if (difference < 0)
        {
            objectRigidBody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);

            if(!underwater)
            {
                underwater = true;
                SwitchState(true);
            }
        }
        else if(underwater)
        {
            underwater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            objectRigidBody.drag = underWaterDrag;
            objectRigidBody.angularDrag = underwaterAngularDrag;
        }
        else
        {
            objectRigidBody.drag = airDrag;
            objectRigidBody.angularDrag= airAngularDrag;
        }
    }
}
