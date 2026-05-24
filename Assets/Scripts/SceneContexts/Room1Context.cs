using UnityEngine;

public class Room1Context : SceneContext
{
    public override void OnSceneReady()
    {
        base.HandleSmoke();

        // Room 1 specific logic: Show dialogue only if player entered the room first time
        if (StoryManager.instance.storyStates[StoryState.PhonePicked] &&
           !StoryManager.instance.storyStates[StoryState.EnterMaiaRoom])
        {
            StoryManager.instance.UpdateStoryState(StoryState.EnterMaiaRoom);
            DialogueManager.instance.StartStoryDialogue("MaiaRoom");
        }
    }
}
