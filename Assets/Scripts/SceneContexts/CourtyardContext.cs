using UnityEngine;
using UnityEngine.UI;
public class CourtyardContext : SceneContext
{
    [SerializeField] GameObject MagicDoor;
    public GameObject PuzzleButton;
    public override void OnSceneReady()
    {
        base.HandleSmoke();

        if (StoryManager.instance.storyStates[StoryState.ExtinguishFlame] &&
           !StoryManager.instance.storyStates[StoryState.SecondCallRing])
        {
            StoryManager.instance.UpdateStoryState(StoryState.SecondCallRing);
            AudioManager.instance.PlayLoopSoundSFX("PhoneRing");
        }
        //this is for if player leaves scene although rn magic door also doesn't reappear in this case
        else if (StoryManager.instance.storyStates[StoryState.PuzzleUnlocked])
        {
            PuzzleButton.GetComponent<Button>().enabled = true;
            PuzzleGame.PuzzleCounter = 0;
        }
        else if (StoryManager.instance.storyStates[StoryState.PotionSuccess])
        {
            MagicDoor.SetActive(true);
            // TODO: We'll deal with this state change once we need have another story state dependent on it
            // StoryManager.instance.UpdateStoryState(StoryState.MagicDoorAppeared);
        }
    }
}
