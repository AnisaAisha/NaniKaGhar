using UnityEngine;

public class Sandooq : FocusedObject
{
    [SerializeField] Sprite sandooqOpen;
    [SerializeField] Sprite sandooqOpenWithoutScales;
    private SpriteRenderer spriteRenderer;
    private Sprite sandooqClosed;
    private bool isSandooqOpen;

    void Start()
    {
        isSandooqOpen = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sandooqClosed = spriteRenderer.sprite;
    }

    public override void Interact()
    {
        SandooqInteraction sandooq = ObjectUIOverlay.GetComponent<SandooqInteraction>();
        if (sandooq != null && sandooq.GetLockStatus())
        {
            ChangeSprite();
            return;
        }
        else
        {
            DOFManager.instance.SetBackgroundBlur(true);
            ObjectUIOverlay.SetActive(true);
        }
    }

    // Change sandooq sprite to open/closed after the lock is open
    void ChangeSprite()
    {
        isSandooqOpen = !isSandooqOpen;
        if (isSandooqOpen) spriteRenderer.sprite = sandooqOpenWithoutScales;
        else spriteRenderer.sprite = sandooqClosed;
    }

    // Listen to the OnStateChange event from StoryManager
    protected override void OnStoryStateChanged(StoryState state)
    {
        if (StoryManager.instance.storyStates[StoryState.LockOpened] && !StoryManager.instance.storyStates[StoryState.ScalesPicked])
        {
            spriteRenderer.sprite = sandooqOpen;
        } else if (StoryManager.instance.storyStates[StoryState.LockOpened] && StoryManager.instance.storyStates[StoryState.ScalesPicked])
        {
            ChangeSprite();
        }
    }
}
