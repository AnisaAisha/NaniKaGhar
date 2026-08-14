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
}
