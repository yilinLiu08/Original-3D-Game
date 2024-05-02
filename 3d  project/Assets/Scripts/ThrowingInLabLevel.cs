using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingInLabLevel : MonoBehaviour
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

    [Header("Animations")]
    public Animator BlueAnimator;  
    public Animator PurpleAnimator;  
    public Animator YellowAnimator;  

    private bool[] unlockedObjects;  
    private int currentObjectIndex; 
    private bool readyToThrow;  

    void Start()
    {
        readyToThrow = true;
        currentObjectIndex = 0;
        UpdateAnimation();

        unlockedObjects = new bool[objectsToThrow.Length];
        for (int i = 0; i < unlockedObjects.Length; i++)
        {
            unlockedObjects[i] = true; 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            do
            {
                currentObjectIndex = (currentObjectIndex + 1) % objectsToThrow.Length;
            }
            while (!unlockedObjects[currentObjectIndex]);
            UpdateAnimation();
        }

        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0 && unlockedObjects[currentObjectIndex])
        {
            Throw();
        }
    }

    private void UpdateAnimation()
    {
        BlueAnimator.SetBool("BlueSelected", currentObjectIndex == 0);
        PurpleAnimator.SetBool("PurpleSelected", currentObjectIndex == 1);
        YellowAnimator.SetBool("YellowSelected", currentObjectIndex == 2);
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
}
