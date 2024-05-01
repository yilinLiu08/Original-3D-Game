using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    
    public Slot[] slotPrefabs;
    public TextMeshProUGUI itemInformation;

    void Awake()
    {
        if (instance != null)
            Destroy(this);

        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    public static void CreateNewItem(Item item)
    {
        
        int index = Mathf.Clamp(item.prefabIndex, 0, instance.slotPrefabs.Length - 1);
        Slot newItem = Instantiate(instance.slotPrefabs[index], instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
        
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;

            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        foreach (var item in instance.myBag.itemList)
        {
            CreateNewItem(item);
        }
    }
}
