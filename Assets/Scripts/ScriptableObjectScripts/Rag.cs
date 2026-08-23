using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Rag")]
public class Rag : InventoryItemData
{
    public bool isStateChanged = false; // by default no state change
    public Sprite changedIcon;
    public bool hitOnce; //to stop rag dialogue from recurring when comparing tag

    public override void InventoryItemInteract(Collider2D hit)
    {
        //hitOnce makes sure wet rag dialogue only appears once
        if (hit.CompareTag("Sink") && !hitOnce) {
            Debug.Log("now the rag is wet!");

            // Update scriptable object for persistent storage
            this.icon = changedIcon;
            isStateChanged = true;
            DialogueManager.instance.StartItemDialogue("Wet Rag", false);
            hitOnce = true;

            // d.sentences = new string[] { "The rag is now drenched in water. Maybe this can put out the fire..." };
            // dialogTrigger.TriggerDialogue(d);
        }
        //hitOnce ensures dry rag dialogue only appears once per drag (see InventoryItem)
        else if (!isStateChanged && hit.CompareTag("Flame") && !hitOnce) {
            AudioManager.instance.PlaySingleSoundSFX("WrongMove");
            DialogueManager.instance.StartStoryDialogue("Rag");
            hitOnce = true;
        //     d.sentences = new string[] { "Maia: I can't use a dry cloth." };
        //     dialogTrigger.TriggerDialogue(d);
        }
        else if (isStateChanged && hit.CompareTag("Flame")) {
            // Turn off the flame
            hit.gameObject.SetActive(false);

            InventoryManager.instance.RemoveItem(this);
            StoryManager.instance.UpdateStoryState(StoryState.ExtinguishFlame);
            AudioManager.instance.StopLoopSoundSFX("Smoke");
            DialogueManager.instance.StartStoryDialogue("Potion");
        }
    }
}
