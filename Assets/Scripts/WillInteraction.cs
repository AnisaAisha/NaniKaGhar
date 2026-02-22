using UnityEngine;

public class WillInteraction : MonoBehaviour
{
    [SerializeField] Sprite willBack;
    [SerializeField] SpriteRenderer willSprite;
    [SerializeField] AudioSource gaspAudio;
    [SerializeField] Animator animator;
    [SerializeField] FadeScene fadeScript;

    private int clickCount;

    void Awake() 
    {
        clickCount = 0;
    }

    void OnMouseDown() 
    {
        Debug.Log(clickCount);
        if (clickCount == 0) {
            willSprite.sprite = willBack;
        } else if (clickCount == 1) {
            animator.SetBool("isInteracted", true);

            Dialogue d = new Dialogue();
            DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
            d.sentences = new string[] {  
                "Maia: Noooo!",
                "...",
                "Jump In?",
                "More Coming Soon..."
            };
            dialogTrigger.SetDialogueInteraction(3, gaspAudio);
            dialogTrigger.SetDialogueInteraction(0, fadeScript);
            dialogTrigger.TriggerDialogue(d);
        }

        clickCount++;

    }

    
}
