using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/GlassShards")]
public class GlassShards : InventoryItemData
{
    //attached to brokenLamp prefab
    public GameObject puzzleOverlay;
    public override void InventoryItemInteract(Collider2D hit)
    {
    
        if (hit != null && PuzzleGame.DoorOverlay) 
        {
            StoryManager.instance.UpdateStoryState(StoryState.PuzzleUnlocked);
            InventoryManager.instance.RemoveItem(this);
        }

    }
    
}
