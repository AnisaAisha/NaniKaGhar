using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke;

    void Start()
    {
        if (!StoryManager.instance.isFireExtinguished) {
            smoke.Play();
        }
        if (StoryManager.instance.isPhonePicked && !StoryManager.instance.isRoomDialogDone) {
            Dialogue d = new Dialogue();
            d.sentences = new string[] { 
                "Maia: Oh no. I forgot about the brewing Sundrip fragrance. I need to put this fire out somehow."
            };

            DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
            dialogTrigger.TriggerDialogue(d);
            StoryManager.instance.isRoomDialogDone = true;
        }
    }
}
