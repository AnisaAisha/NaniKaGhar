using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    Button inventoryButton;
    GameObject inventoryMenu;
    [SerializeField] GameObject itemSlot;

    private bool isMenuActive;
    private List<InventoryItemData> inventoryList;
    private List<GameObject> inventoryObjList;

    void Awake() {
        // Singleton check
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return; // IMPORTANT: stop execution
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize only once
        inventoryList = new List<InventoryItemData>();
        inventoryObjList = new List<GameObject>();
        isMenuActive = false;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
         Debug.Log("Scene Loaded");

        inventoryMenu = GameObject.Find("InventoryPanel");
        inventoryMenu.SetActive(false);
        if (inventoryMenu == null)
        {
            Debug.LogError("InventoryPanel not found in scene!");
            return;
        }

        inventoryButton = GameObject.Find("InventoryButton")?.GetComponent<Button>();
        if (inventoryButton != null)
        {
            inventoryButton.onClick.RemoveAllListeners();
            inventoryButton.onClick.AddListener(ToggleMenu);
        }

        RebuildInventoryUI();
    }

    void RebuildInventoryUI()
    {
        Debug.Log(inventoryObjList.Count);
        // inventoryObjList.Clear();

        foreach (var item in inventoryList)
        {
            Debug.Log(itemSlot);
            Debug.Log(inventoryMenu);
            GameObject newItem = Instantiate(itemSlot, inventoryMenu.transform);

            newItem.GetComponent<InventoryItem>().itemData = item;
            newItem.GetComponent<Image>().sprite = item.icon;

            inventoryObjList.Add(newItem);
        }
    }

    public void AddItem(InventoryItemData item) {
        Debug.Log(item);
        inventoryList.Add(item);

        GameObject newInventoryItem = Instantiate(itemSlot, new Vector3(0, 0, 0), Quaternion.identity);
        newInventoryItem.GetComponent<InventoryItem>().itemData = item;
        newInventoryItem.GetComponent<Image>().sprite = item.icon;
        newInventoryItem.transform.parent = inventoryMenu.transform;

        inventoryObjList.Add(newInventoryItem);
        // Debug.Log(inventoryList);
    }

    public void ToggleMenu()
    {
        Debug.Log("Inventory Button Clicked!");
        isMenuActive = !isMenuActive;
        inventoryMenu.SetActive(isMenuActive);  
    }
}
