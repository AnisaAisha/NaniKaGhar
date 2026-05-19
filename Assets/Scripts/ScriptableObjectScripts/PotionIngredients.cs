using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/PotionIngredients")]
public class PotionIngredients : InventoryItemData
{
    public override void InventoryItemInteract(Collider2D hit)
    {
        if (hit.CompareTag("Stove")) {
            // Trigger dialogue
            // d.sentences = new string[] {  $"{itemData.name} added to the pot!", };
            // dialogTrigger.TriggerDialogue(d);

            Debug.Log(name + " added to the pot!");

            InventoryManager.instance.RemoveItem(this);

            StoryManager.instance.AddStoveItems(this.name); // Temporary; to remove later
        }
    }
    
}
