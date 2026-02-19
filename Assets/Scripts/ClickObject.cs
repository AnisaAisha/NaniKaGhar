using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [SerializeField] GameObject objGameObject;
    [SerializeField] InventoryItem item;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] DialogueTrigger dialogTrigger;

    public void OnMouseDown() {
        Dialogue d = new Dialogue();
        d.sentences = new string[] { $"{item.name} added to inventory!" };

        dialogTrigger.TriggerDialogue(d);
        inventoryManager.AddItem(item.itemData);
        Destroy(objGameObject);
    }
}
