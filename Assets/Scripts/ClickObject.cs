using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [SerializeField] GameObject objGameObject;
    [SerializeField] InventoryItemData itemData;
    // [SerializeField] InventoryManager inventoryManager;
    [SerializeField] DialogueTrigger dialogTrigger;

    public void OnMouseDown() {
        Dialogue d = new Dialogue();
        d.sentences = new string[] { $"{itemData.name} added to inventory!" };

        dialogTrigger.TriggerDialogue(d);
        InventoryManager.instance.AddItem(itemData);
        Destroy(objGameObject);
    }
}
