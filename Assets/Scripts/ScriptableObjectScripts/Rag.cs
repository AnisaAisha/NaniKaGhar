using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Rag")]
public class Rag : InventoryItemData
{
    public bool isStateChanged = false; // by default no state change
    public Sprite changedIcon;

    public override void InventoryItemInteract(Collider2D hit)
    {
        if (hit.CompareTag("Sink")) {
            Debug.Log("now the rag is wet!");

            // Update scriptable object for persistent storage
            this.icon = changedIcon;
            isStateChanged = true;

            // d.sentences = new string[] { "The rag is now drenched in water. Maybe this can put out the fire..." };
            // dialogTrigger.TriggerDialogue(d);
        }
        else if (!isStateChanged && hit.CompareTag("Flame")) {
            Debug.Log("Maia says we cannot use a dry cloth!");
        //     d.sentences = new string[] { "Maia: I can't use a dry cloth." };
        //     dialogTrigger.TriggerDialogue(d);
        }
        else if (isStateChanged && hit.CompareTag("Flame")) {
            // Turn off the flame and smoke
            hit.gameObject.SetActive(false);
            StoryManager.instance.UpdateStoryState(StoryState.ExtinguishFlame);

            AudioManager.instance.StopLoopSoundSFX("Smoke");

            ParticleSystem smoke = GameObject.Find("Smoke").GetComponent<ParticleSystem>(); // CHANGE THIS
            smoke.Stop();
            // crackling.Stop();
            // StartCoroutine(AddDelay());

            DialogueManager.instance.StartStoryDialogue("Potion");
        }
    }
}
