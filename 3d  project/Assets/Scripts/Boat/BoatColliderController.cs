using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatColliderController : MonoBehaviour
{
    public BoxCollider boatCollider;
    bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        boatCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            boatCollider.isTrigger = true;
        }
        else
        {
            boatCollider.isTrigger = false;
        }
    }
}
