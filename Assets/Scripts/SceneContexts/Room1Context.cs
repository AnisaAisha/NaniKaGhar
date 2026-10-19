using UnityEngine;

public class Room1Context : SceneContext
{
    [SerializeField] GameObject flame;
    [SerializeField] SandooqInteraction sandooqUI;
    // Note: Probably make the potion scriptable object
    [SerializeField] SpriteRenderer potionRenderer;
    [SerializeField] Sprite burntPotion;
    [SerializeField] GameObject lamp;
    [SerializeField] GameObject brokenLamp;
    [SerializeField] Mallet mallet;

    public override void OnSceneReady()
    {
        base.HandleSmoke();

        // TODO: Add sprite change (with open sandooq without scales sprite)
        sandooqUI.SetLockStatus(StoryManager.instance.storyStates[StoryState.LockOpened]);

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

        if (mallet.lampBroken)
        {
            Destroy(lamp);
            Instantiate(brokenLamp); //so that it is still there in scene reload if player doesn't pick it up
        }
    }

    void OnEnable() 
    {
        StoryManager.OnStoryStateChanged += OnStoryStateChanged;
    }

    void OnDisable()
    {
        StoryManager.OnStoryStateChanged -= OnStoryStateChanged;
    }

    void OnStoryStateChanged(StoryState newState) {
        if (StoryManager.instance.currentState == StoryState.ExtinguishFlame)
        {
            potionRenderer.sprite = burntPotion;
            smoke.Stop();
        }
    }

}
