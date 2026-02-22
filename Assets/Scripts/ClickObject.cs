using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [SerializeField] GameObject objGameObject;
    [SerializeField] InventoryItemData itemData;
    // [SerializeField] InventoryManager inventoryManager;
    [SerializeField] DialogueTrigger dialogTrigger;

    public void OnMouseDown() {
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
        Destroy(objGameObject);
    }
}
