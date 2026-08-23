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
        AudioManager.instance.StopLoopSoundSFX("PhoneRing"); //shifted this here

        if (StoryManager.instance.currentState == StoryState.PhoneRinging)
        {
            DialogueManager.instance.StartStoryDialogue("Phone");
            AudioManager.instance.PlaySingleSoundSFX("PhonePickup");
            StoryManager.instance.UpdateStoryState(StoryState.PhonePicked);
        }
        else if (StoryManager.instance.currentState == StoryState.SecondCallRing)
        {
            DialogueManager.instance.StartStoryDialogue("SecondCall");
            AudioManager.instance.PlaySingleSoundSFX("PhonePickup");
            StoryManager.instance.UpdateStoryState(StoryState.SecondCallPicked);
        }    
        else if (StoryManager.instance.currentState == StoryState.ThirdCallRing)
        {  
            AudioManager.instance.PlaySingleSoundSFX("PhonePickup");
            DialogueManager.instance.StartStoryDialogue("ThirdCall");
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
            StartCoroutine(RingAfterDelay(10f));
        }
    }
}
