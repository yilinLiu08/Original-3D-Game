using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory PlayerInventory; 

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem() 
    {
        if (!PlayerInventory.itemList.Contains(thisItem)) 
        {
            PlayerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            print("create new item");
        }
        else
        {
            thisItem.itemHeld += 1;
            print("+= 1");
        }
        InventoryManager.RefreshItem();
    }
}
