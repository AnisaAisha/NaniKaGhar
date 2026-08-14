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
        // First time after potion success display dialogue
        else if (StoryManager.instance.storyStates[StoryState.PotionSuccess] &&
                !StoryManager.instance.storyStates[StoryState.MagicDoorAppeared])
        {
            StoryManager.instance.UpdateStoryState(StoryState.MagicDoorAppeared);
            DialogueManager.instance.StartStoryDialogue("MagicDoorAppear");
        }
        //this is for if player leaves scene although rn magic door also doesn't reappear in this case
        else if (StoryManager.instance.storyStates[StoryState.PuzzleUnlocked])
        {
            PuzzleButton.GetComponent<Button>().enabled = true;
            PuzzleGame.PuzzleCounter = 0;
        }

        // If potion is successful, ALWAYS show the magic door
        if (StoryManager.instance.storyStates[StoryState.PotionSuccess])
        {
            MagicDoor.SetActive(true);
        }
    }
}
