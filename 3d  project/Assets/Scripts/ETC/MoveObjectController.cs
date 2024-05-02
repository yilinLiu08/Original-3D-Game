using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectController : MonoBehaviour
{
    public GameObject doorElementUnlock;
    public MoveObject moveObject;
    public Collider boxCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorElementUnlock.activeInHierarchy)
        {
            boxCollider.enabled = false;
            moveObject.enabled = true;
        }
        else
        {
            boxCollider.enabled = true;
            moveObject.enabled = false;
        }
    }
}
