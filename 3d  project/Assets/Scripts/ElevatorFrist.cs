using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorFirst : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject fButtonUI;
    private bool isPlayerInRange = false;
    public Transform playerTransform;
    public AudioSource elevator;


    public Inventory playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            playerTransform = other.transform;
            fButtonUI.SetActive(true);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            elevator.Play();

            if (HasKeyInInventory(playerInventory))
            {
                playerTransform.position = teleportTarget.position;
                fButtonUI.SetActive(false);
            }
            else
            {
                Debug.Log("You do not have the key!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            fButtonUI.SetActive(false);
        }
    }

    
    private bool HasKeyInInventory(Inventory inventory)
    {
        foreach (Item item in inventory.itemList)
        {
            if (item.itemName == "Keycard")
            {
                return true;
            }
        }
        return false;
    }
}
