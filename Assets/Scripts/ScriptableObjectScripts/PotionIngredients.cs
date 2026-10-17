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
            AudioManager.instance.PlaySingleSoundSFX("IngredientInPot");

            Debug.Log(name + " added to the pot!");

            DialogueManager.instance.StartItemDialogue(this.name, true);

            InventoryManager.instance.RemoveItem(this);

            StoryManager.instance.AddStoveItems(this.name); // Temporary; to remove later

            // shift this to wherever knob appearing code will be cuz rn this won't work unless order of events is followed
            if (StoryManager.instance.GetCurrentStoveIngredients().Count == 4 && StoryManager.instance.currentState == StoryState.SecondCallPicked)
            {
                AudioManager.instance.PlaySingleSoundSFX("KnobAppears");
            }
        }
    }
    
}
