using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StandingOnPlatform : MonoBehaviour
{
    public GameObject playerStanding;
    public GameObject playerSitting;
    

    public bool interactable;
    public bool sitting;


    

    private void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("player");
            
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                
                playerSitting.SetActive(true);
                sitting = true;
                playerStanding.SetActive(false);
                interactable = false;
                Debug.Log("toggle on");
                
            }
        }
        if (sitting == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerSitting.SetActive(false);
                
                playerStanding.SetActive(true);
                sitting = false;
                Debug.Log("toggle off");
               
            }
        }
    }
}