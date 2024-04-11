using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GridSelection : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public int selectedIndex = -1;
    public Color selectedColor = Color.red;
    private Color defaultColor = Color.white;

    
    public InventoryManager inventoryManager;

    void Start()
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                child.GetComponent<Image>().color = defaultColor;
            }
        }
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (scroll > 0)
            {
                selectedIndex++;
            }
            else
            {
                selectedIndex--;
            }

            selectedIndex = Mathf.Clamp(selectedIndex, 0, gridLayoutGroup.transform.childCount - 1);

            HighlightSelectedItem();
            
            UpdateItemInformation();
        }
    }

    void HighlightSelectedItem()
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            if (child.GetComponent<Image>() != null)
            {
                child.GetComponent<Image>().color = defaultColor;
            }
        }

        Transform selectedItem = gridLayoutGroup.transform.GetChild(selectedIndex);
        if (selectedItem.GetComponent<Image>() != null)
        {
            selectedItem.GetComponent<Image>().color = selectedColor;
        }
    }

    
    void UpdateItemInformation()
    {
        if (inventoryManager != null && selectedIndex < inventoryManager.myBag.itemList.Count)
        {
            Item selectedItem = inventoryManager.myBag.itemList[selectedIndex];
            InventoryManager.UpdateItemInfo(selectedItem.itemInfor);
        }
    }
}
