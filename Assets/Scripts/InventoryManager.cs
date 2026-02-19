using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryMenu;
    [SerializeField] GameObject itemSlot;
    private bool isMenuActive;
    private List<InventoryItemData> inventoryList;

    void Awake() {
        inventoryList = new List<InventoryItemData>();
        isMenuActive = false;
    }

    public void AddItem(InventoryItemData item) {
        inventoryList.Add(item);

        GameObject newInventoryItem = Instantiate(itemSlot, new Vector3(0, 0, 0), Quaternion.identity);
        itemSlot.GetComponent<Image>().sprite = item.icon;
        newInventoryItem.transform.parent = inventoryMenu.transform;
        // Debug.Log(inventoryList);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            isMenuActive = !isMenuActive;
            inventoryMenu.SetActive(isMenuActive);  
        } 
    }
}
