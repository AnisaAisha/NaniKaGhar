using UnityEngine;

// Objects that can be picked up by the player (inventory items)
public class PickupObject : Interactables
{
    // TODO: MAKE ALL INVENTORY OBJECTS PREFABS
    [SerializeField] InventoryItemData itemData;
    [SerializeField] private string sceneObjectID; // Must be same as inventoryitemdata ID

    void Start()
    {
        // If item has been picked up by player (saved in pickup list in game manager), don't load it again
        if (GameManager.instance != null && GameManager.instance.IsPickedup(sceneObjectID))
        {
            Destroy(gameObject);
        }
    }

    void DeleteObject() // nitpick: replace with EndInteract?
    {
        // itemData.isDeleted = true; // set object to delete in SO
        Destroy(this.gameObject);
    }

    public override void Interact() {

        Debug.Log("Interacting with object...." + itemData.name);

        if (itemData.id == "item_scales") {
            StoryManager.instance.UpdateStoryState(StoryState.ScalesPicked);
        }

        DialogueManager.instance.StartItemDialogue(itemData.name);
        InventoryManager.instance.AddItem(itemData);

        if (GameManager.instance != null)
        {
            GameManager.instance.CollectPickupItem(sceneObjectID);
        }

        DeleteObject();
    }
}
