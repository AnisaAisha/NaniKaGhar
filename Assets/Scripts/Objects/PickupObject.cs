using UnityEngine;

// Objects that can be picked up by the player (inventory items)
public class PickupObject : Interactables
{
    // TODO: MAKE ALL INVENTORY OBJECTS PREFABS
    [SerializeField] InventoryItemData itemData;
    [SerializeField] DialogueTrigger dialogTrigger;

    void Awake() {
        // If SO property says object is deleted, don't load it
        if (itemData.isDeleted) {
            DeleteObject();
        }
    }

    void DeleteObject() // nitpick: replace with EndInteract?
    {
        itemData.isDeleted = true; // set object to delete in SO
        Destroy(this.gameObject);
    }

    public override void Interact() {
        Dialogue d = new Dialogue();

        if (itemData.name == "Jalpari Scales") {
            InventoryManager.instance.isContainScales = true;
            d.sentences = new string[] { 
                $"{itemData.name} added to inventory!",
                "Maia: Guess I have no reason to hide these things anymore." 
            };
            GameObject.Find("sandooq open_0").SetActive(false);
        } else {
            d.sentences = new string[] { $"{itemData.name} added to inventory!" };
        }

        dialogTrigger.TriggerDialogue(d);
        InventoryManager.instance.AddItem(itemData);
        DeleteObject();
    }
}
