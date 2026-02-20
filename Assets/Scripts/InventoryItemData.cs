using UnityEngine;

[CreateAssetMenu]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string name;
    public bool isDry;
    public Sprite icon;
}