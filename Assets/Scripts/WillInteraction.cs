using UnityEngine;
using UnityEngine.UI;

public class WillInteraction : UIInteractables
{
    [SerializeField] Sprite willBack;
    [SerializeField] Animator animator;
    private Image willImage;
    private int clickCount;

    void Awake() 
    {
        clickCount = 0;
        willImage = GetComponent<Image>();
    }

    // TODO: Use enums instead of click counts
    public override void InteractUI()
    {
        Debug.Log(clickCount);
        if (clickCount == 0) {
            willImage.sprite = willBack;
        } else if (clickCount == 1) {
            animator.SetBool("isInteracted", true);

            DialogueManager.instance.StartStoryDialogue("Void");
        }

        clickCount++;

    }

    
}
