using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public GameObject fButtonUI;  
    private bool isPlayerInRange = false;  

    void Start()
    {
        fButtonUI.SetActive(false);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;  
            fButtonUI.SetActive(true);  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;  
            fButtonUI.SetActive(false);  
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))  
        {
            AddNewItem();
            Destroy(gameObject);  
            fButtonUI.SetActive(false);  
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            thisItem.itemHeld = 1;
            playerInventory.itemList.Add(thisItem);
            Debug.Log("create new item");
        }
        else
        {
            thisItem.itemHeld += 1;
            Debug.Log("+= 1");
        }
        InventoryManager.RefreshItem();
    }
}
