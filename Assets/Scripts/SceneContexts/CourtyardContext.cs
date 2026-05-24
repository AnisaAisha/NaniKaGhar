using UnityEngine;

public class CourtyardContext : SceneContext
{
    [SerializeField] GameObject MagicDoor;
    public override void OnSceneReady()
    {
        base.HandleSmoke();

        if (StoryManager.instance.storyStates[StoryState.ExtinguishFlame] &&
           !StoryManager.instance.storyStates[StoryState.SecondCallRing])
        {
            StoryManager.instance.UpdateStoryState(StoryState.SecondCallRing);
            AudioManager.instance.PlayLoopSoundSFX("PhoneRing");
        }
        else if (StoryManager.instance.storyStates[StoryState.PotionSuccess] &&
           !StoryManager.instance.storyStates[StoryState.MagicDoorAppeared])
        {
            MagicDoor.SetActive(true);
            StoryManager.instance.UpdateStoryState(StoryState.MagicDoorAppeared);
        }
    }
}
