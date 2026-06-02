using UnityEngine;

public class Room1Context : SceneContext
{
    [SerializeField] GameObject flame;
    public override void OnSceneReady()
    {
        base.HandleSmoke();

        // Room 1 specific logic: Show dialogue only if player entered the room first time
        if (StoryManager.instance.storyStates[StoryState.PhonePicked] &&
           !StoryManager.instance.storyStates[StoryState.EnterMaiaRoom])
        {
            StoryManager.instance.UpdateStoryState(StoryState.EnterMaiaRoom);
            DialogueManager.instance.StartStoryDialogue("MaiaRoom");
        } else if (StoryManager.instance.storyStates[StoryState.ExtinguishFlame])
        {
            // TODO: Perhaps make this a scriptable object?
            flame.SetActive(false); // if flame is extinguished, don't show it
        }
    }
}
