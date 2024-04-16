using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueElementalScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Destroy(gameObject);
        }
    }
}