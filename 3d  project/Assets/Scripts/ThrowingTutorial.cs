using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingTutorial : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject[] objectsToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public KeyCode switchKey = KeyCode.Alpha1;
    public float throwForce;
    public float throwUpwardForce;

   
    //private bool[] unlockedObjects;

    private int currentObjectIndex;
    private bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
        currentObjectIndex = 0;

        
       /* unlockedObjects = new bool[objectsToThrow.Length];
        unlockedObjects[0] = true; 
        for (int i = 1; i < unlockedObjects.Length; i++)
        {
            unlockedObjects[i] = false; 
        }*/
    }

    private void Update()
    {

        if (Input.GetKeyDown(switchKey))
        {
            currentObjectIndex = (currentObjectIndex + 1) % objectsToThrow.Length;
        }

        /*if (Input.GetKeyDown(switchKey))
        {
            
            do
            {
                currentObjectIndex = (currentObjectIndex + 1) % objectsToThrow.Length;
            }
            while (!unlockedObjects[currentObjectIndex]); 
        }*/

        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectsToThrow[currentObjectIndex], attackPoint.position, cam.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        Vector3 forceDirection = cam.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }


    /* public void UnlockObject(int index)
    {
        if (index >= 0 && index < unlockedObjects.Length)
        {
            unlockedObjects[index] = true;
        }
    }*/
}
