using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDoorController : MonoBehaviour
{
    public GameObject element;
    // Start is called before the first frame update
    void Start()
    {
        element.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBall"))
        {
            element.SetActive(true);
        }
    }

}
