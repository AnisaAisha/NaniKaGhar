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
    // [SerializeField] StoryManager storyManager;

    private bool isPhoneRingTriggered;
    private bool isPhoneRinging;
    private bool isPhonePicked;

    void Awake() 
    {
        isPhoneRingTriggered = false;
        isPhoneRinging = false;
        isPhonePicked = false;
    }

    public void OnMouseDown()
    {
        phoneRing.Stop();
        isPhoneRinging = false;
        isPhonePicked = true;
        Debug.Log(name + " Game Object Clicked!");
        StartPhoneDialogue();
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
        dialogTrigger.SetDialogueInteraction(1, smoke);
    }

    void PlayPhonecutSFX() {
        phoneCut.Play();
    }

    IEnumerator RingAfterDelay() 
    {
        Debug.Log("adding delay...");
        
        yield return new WaitForSeconds(1f);

        isPhoneRinging = true;
        Debug.Log("Phone has started ringing...");
        
        phoneRing.Play();
    }

    void Update() 
    {
        if (letter.isLetterOpened && !isPhoneRingTriggered) {
            isPhoneRingTriggered= true;
            StartCoroutine(RingAfterDelay());
        }
    }
}
