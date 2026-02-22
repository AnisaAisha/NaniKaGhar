using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke;
    [SerializeField] AudioSource smokeSound;

    void Start()
    {
        if (!StoryManager.instance.isFireExtinguished && StoryManager.instance.isPhonePicked) {
            smoke.Play();
            smokeSound.Play();
        }
        if (StoryManager.instance.isPhonePicked && !StoryManager.instance.isRoomDialogDone) {
            Dialogue d = new Dialogue();
            d.sentences = new string[] { 
                "Maia: Oh no. I forgot about the brewing Sundrip fragrance. I need to go find a rag somewhere."
            };

            DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
            dialogTrigger.TriggerDialogue(d);
            StoryManager.instance.isRoomDialogDone = true;
        }
    }
}
