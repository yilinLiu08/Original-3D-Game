using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SitController : MonoBehaviour
{
    public GameObject playerStanding;
    public GameObject playerSitting;
    public GameObject intText; 
    public GameObject standText;

    public bool interactable;
    public bool sitting;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                intText.SetActive(false);
                standText.SetActive(true);
                playerSitting.SetActive(true);
                sitting = true;
                playerStanding.SetActive(false);
                interactable = false;
            }
        }
        if (sitting == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerSitting.SetActive(false);
                standText.SetActive(false);
                playerStanding.SetActive(true);
                sitting = false;
            }
        }
    }
}
