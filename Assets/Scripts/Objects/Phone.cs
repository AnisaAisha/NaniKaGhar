using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using System.Collections;
using Yarn.Unity;

public class Phone : Interactables
{
    [SerializeField] ParticleSystem smoke;

    public override void Interact()
    {
        // ONLY start the dialogue and change state if the phone is ringing
        if (StoryManager.instance.currentState == StoryState.PhoneRinging)
        {
            AudioManager.instance.StopLoopSoundSFX("PhoneRing");
            DialogueManager.instance.StartStoryDialogue("Phone");
            StoryManager.instance.UpdateStoryState(StoryState.PhonePicked);
        } 
        else if (StoryManager.instance.currentState == StoryState.SecondCallRing)
        {
            AudioManager.instance.StopLoopSoundSFX("PhoneRing");
            DialogueManager.instance.StartStoryDialogue("SecondCall");
            StoryManager.instance.UpdateStoryState(StoryState.SecondCallPicked);
        }    
    }

    [YarnCommand("smoke")]
    public void StartSmoke()
    {
        smoke.Play();
    }

    // probably handle this in the yarn script
    IEnumerator RingAfterDelay(float delay) 
    {
        Debug.Log("adding delay...");
        yield return new WaitForSeconds(delay);

        Debug.Log("Phone has started ringing...");        
        AudioManager.instance.PlayLoopSoundSFX("PhoneRing");

        // Change story state 
        StoryManager.instance.UpdateStoryState(StoryState.PhoneRinging);
    }

    protected override void OnStoryStateChanged(StoryState newState)
    {
        if (StoryManager.instance.currentState == StoryState.LetterOpened)
        {
            StartCoroutine(RingAfterDelay(3f));
        }
    }
}
