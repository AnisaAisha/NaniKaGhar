using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using System.Collections;

public class PhoneInteraction : MonoBehaviour
{
    [SerializeField] AudioSource phoneRing;
    [SerializeField] AudioSource phoneCut;
    [SerializeField] LifafaInteraction letter;
    [SerializeField] ParticleSystem smoke;
    [SerializeField] AudioSource SmokeSound;
    

    private bool isPhoneRingTriggered;
    private bool isPhoneRinging;
    private bool isPhonePicked;

    void Awake() 
    {
        isPhoneRingTriggered = false;
        isPhoneRinging = false;
        isPhonePicked = false;
    }

    void Start()
    {
        if (StoryManager.instance.isDiaryOpened && !StoryManager.instance.isSecondPhoneRingOnce)
        {
            Debug.Log("Scene loaded and diary was already opened");

            phoneRing.Play();
            StoryManager.instance.isSecondPhoneRingOnce = true;
        }
    }

    public void OnMouseDown()
    {
        phoneRing.Stop();
        // isPhoneRinging = false;
        // isPhonePicked = true;
        // Debug.Log(name + " Game Object Clicked!");
        if (StoryManager.instance.isDiaryOpened) {
            StartSecondPhoneDialogue();
        } else if (StoryManager.instance.isLetterOpened) {
            SmokeSound.Play();
            smoke.Play();
            StartPhoneDialogue();
            StoryManager.instance.isPhonePicked = true;
        }
    }

    void StartPhoneDialogue() 
    {
        Dialogue d = new Dialogue();
        d.sentences = new string[] { 
            "Mamu: Maia beta, how is the packing coming along?",
            "Maia: Hello mamu. I hope you are well too. I actually haven't started packing yet. Just got your letter.",
            "Mamu: What? That can't be right. I mailed it more than a week ago. You must have missed it.",
            "Mamu: That is understandable. However, nothing we can do about it. The movers will be there in the evening. Just clear out the furniture by then so they can take those away.",
            "Maia: But I -",
            "Mamu: Take care.",
            "Maia: *Sigh*. Where do I even start? Wait, what is that smell?"
        };

        DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        dialogTrigger.TriggerDialogue(d);

        // Since sentences are a queue, taking the index from bottom (to fix later)
        dialogTrigger.SetDialogueInteraction(2, phoneCut);
        // dialogTrigger.SetDialogueInteraction(4, smoke);
    }

     void StartSecondPhoneDialogue() 
    {
        Dialogue d = new Dialogue();
        d.sentences = new string[] { 
            "Mamu: Maia, just talked to the movers, they'll be there at 6pm.",
            "Maia: Mamu...I don't think I can do this.",
            "Mamu: Sure, you can. The value of Nani ka Ghar will only depreciate further the longer we wait.",
            "Mamu: You know, I have been insisting on selling this house for a long time. Only your nani wouldn't listen...",
            "Maia: I just...I need more time.",
            "Mamu: We don't have time beta. Pick yourself up, c'mon.",
            "..."
        };

        DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        dialogTrigger.TriggerDialogue(d);

        // Since sentences are a queue, taking the index from bottom (to fix later)
        dialogTrigger.SetDialogueInteraction(0, phoneCut);
    }

    void PlayPhonecutSFX() {
        phoneCut.Play();
    }

    IEnumerator RingAfterDelay(float delay) 
    {
        Debug.Log("adding delay...");
        
        yield return new WaitForSeconds(delay);

        isPhoneRinging = true;
        Debug.Log("Phone has started ringing...");
        
        phoneRing.Play();
    }

    void Update() 
    {
        if (letter.isLetterOpened && !isPhoneRingTriggered) {
            isPhoneRingTriggered= true;
            StartCoroutine(RingAfterDelay(3f));
        }
    }
}
