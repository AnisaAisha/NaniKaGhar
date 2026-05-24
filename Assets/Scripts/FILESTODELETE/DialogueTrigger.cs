using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] Dialogue dialogue; 

    public void OnTriggerEnter2D() {
        TriggerDialogue();
    }

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerDialogue(Dialogue dialog) {
        FindObjectOfType<DialogueManager>().StartDialogue(dialog);
    }

    public void SetDialogueInteraction(int dialogIndex, object item) {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        dm.GetComponent<DialogueManager>().dialogInteraction = true;
        dm.SetDialogueInteraction(dialogIndex, item);
    }
}
