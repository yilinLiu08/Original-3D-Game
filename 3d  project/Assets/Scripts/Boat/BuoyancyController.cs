using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyController : MonoBehaviour
{
    public Transform[] floaters;

    public float underWaterDrag = 3f;
    public float underwaterAngularDrag = 1f;

    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 0f;

    Rigidbody objectRigidBody;

    int floatersUnderwater;

    bool underwater;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        floatersUnderwater = 0;
        for (int i = 0; i < floaters.Length; i++)
        {
            float difference = floaters[i].position.y - waterHeight;

            if (difference < 0)
            {
                objectRigidBody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floaters[i].position, ForceMode.Force);
                floatersUnderwater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
        }

        if(underwater && floatersUnderwater == 0)
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
