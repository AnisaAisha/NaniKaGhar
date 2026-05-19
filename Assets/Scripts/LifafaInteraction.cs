using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LifafaInteraction : UIInteractables //MonoBehaviour, IPointerClickHandler
{
    // [SerializeField] GameObject peekingLetter;
    [SerializeField] GameObject letter;
    // [SerializeField] GameManager gameManager;
    // [SerializeField] Image sr;

    // public bool isLetterOpened;

    public override void InteractUI()
    {
        gameObject.SetActive(false); // Lifafa is not visible now
        letter.SetActive(true);
        // StoryManager.instance.isLetterOpened = true;

        // StoryManager.instance.UpdateStoryState(Objective.OpenLetter, true);
    }

    public override void EndInteractUI() // CloseLetter() {
    { 
        letter.SetActive(false);
        // Dialogue d = new Dialogue();
        // d.sentences = new string[] { "Maia: By Sunday? But that's today. I think mamu must have mailed this earlier. It's possible the post was delayed by the rain." };

        // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        // dialogTrigger.TriggerDialogue(d);

        DialogueManager.instance.StartStoryDialogue("Letter");
        // isLetterOpened = true;
        DOFManager.instance.SetBackgroundBlur(false);

        // Move to next state ONLY after the letter is closed
        // StoryManager.instance.UpdateStoryState(StoryState.LetterOpened);
    }
}
