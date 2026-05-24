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

        Debug.Log("Interacting with object...." + itemData.name);

        if (itemData.name == "Jalpari Scales") {
            InventoryManager.instance.isContainScales = true;
            GameObject.Find("sandooq open_0").SetActive(false); // CHANGE THIS

            DialogueManager.instance.StartStoryDialogue("JalpariScales");
        }
        //     d.sentences = new string[] { 
        //         $"{itemData.name} added to inventory!",
        //         "Maia: Guess I have no reason to hide these things anymore." 
        //     };
        // } else {
        //     d.sentences = new string[] { $"{itemData.name} added to inventory!" };
        // }

        // dialogTrigger.TriggerDialogue(d);

        DialogueManager.instance.StartItemDialogue(itemData.name);

        InventoryManager.instance.AddItem(itemData);
        DeleteObject();
    }
}
