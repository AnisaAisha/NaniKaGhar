using UnityEngine;
using UnityEngine.UI;
public class KitchenContext : SceneContext
{
    public override void OnSceneReady()
    {
        if (StoryManager.instance.storyStates[StoryState.PotionSuccess])        
        {
            smoke?.Play();
        }
    }

    //AudioManager.instance.PlayLoopSoundSFX("SinkDrip"); looping sound cancels smoke sound
    /**void OnDisable() 
    {
        AudioManager.instance.StopLoopSoundSFX("SinkDrip");
    }*/
}
