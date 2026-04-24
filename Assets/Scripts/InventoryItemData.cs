using UnityEngine;

[CreateAssetMenu]
public class InventoryItemData : ScriptableObject
{
    public string id; // do we really need this?
    public string name;
    public bool isDry;
    public bool isPotionIngredient;
    public Sprite icon;
    public Sprite changedIcon;
    public bool isDeleted;
}