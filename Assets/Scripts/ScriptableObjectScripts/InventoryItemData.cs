using UnityEngine;

[CreateAssetMenu]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string name;
    public Sprite icon;

    // Each inventory item overrides and writes its own interaction
    public virtual void InventoryItemInteract(Collider2D hitInfo) {}
}