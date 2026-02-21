using UnityEngine;

public class WillInteraction : MonoBehaviour
{
    [SerializeField] Sprite willBack;
    [SerializeField] SpriteRenderer willSprite;
    [SerializeField] AudioSource gaspAudio;

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
            // willSprite.color += new Color(1f, 1f, 1f, 0f);
            Color c = willSprite.color;
            c.a = 0f;
            willSprite.color = c;

            Dialogue d = new Dialogue();
            DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
            d.sentences = new string[] {  
                "Maia: Noooo!",
                "...",
                "Jump In?",
                "More Coming Soon..."
            };
            dialogTrigger.SetDialogueInteraction(3, gaspAudio);

            dialogTrigger.TriggerDialogue(d);

            // dialogTrigger.SetDialogueInteraction(0, "fade");
        }

        clickCount++;
    }
}
