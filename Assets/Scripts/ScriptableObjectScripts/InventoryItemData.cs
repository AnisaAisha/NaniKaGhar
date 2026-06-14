using UnityEngine;

[CreateAssetMenu]
public class InventoryItemData : ScriptableObject
{
    public string id; // do we really need this?
    public string name;
    public Sprite icon;
    public bool isDeleted;

    void Awake()
    {
        isDeleted = false;
    }

    // Each inventory item overrides and writes its own interaction
    public virtual void InventoryItemInteract(Collider2D hitInfo) {}
}