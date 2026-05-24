using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LifafaInteraction : UIInteractables
{
    // [SerializeField] GameObject peekingLetter;
    [SerializeField] GameObject letter;

    public override void InteractUI()
    {
        gameObject.SetActive(false); // Lifafa is not visible now
        letter.SetActive(true);
    }

    public override void EndInteractUI()
    { 
        letter.SetActive(false);
        DialogueManager.instance.StartStoryDialogue("Letter");

        DOFManager.instance.SetBackgroundBlur(false);

        // Move to next state ONLY after the letter is closed
        StoryManager.instance.UpdateStoryState(StoryState.LetterOpened);
    }
}
