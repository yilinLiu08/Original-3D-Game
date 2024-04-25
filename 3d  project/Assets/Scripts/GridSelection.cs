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
    public starvation HungerController;

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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ActivateSlotScript();
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

    void ActivateSlotScript()
    {
        Transform selectedItem = gridLayoutGroup.transform.GetChild(selectedIndex);
        Item item = inventoryManager.myBag.itemList[selectedIndex];

        if (selectedItem.CompareTag("Can"))
        {
            RestoreHunger();
        }
        else if (selectedItem.CompareTag("FirstAid"))
        {
            Debug.LogError("Recover blood");
        }

       
        item.itemHeld--;
        if (item.itemHeld <= 0)
        {
            inventoryManager.myBag.itemList.Remove(item);
            Destroy(selectedItem.gameObject);
            InventoryManager.RefreshItem();  // È·±£Ë¢ÐÂUI
        }


        InventoryManager.RefreshItem();
    }

    void RestoreHunger()
    {
        HungerController.hunger += 30f;
        HungerController.hunger = Mathf.Min(HungerController.hunger, 100f);
        HungerController.HungerBar.fillAmount = HungerController.hunger / 100f;
    }
}
