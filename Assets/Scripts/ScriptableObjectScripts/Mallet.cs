using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Inventory/Mallet")]
public class Mallet : InventoryItemData
{
    public GameObject brokenLamp;
    public bool lampBroken;
    
    public override void InventoryItemInteract(Collider2D hit)
    {
    
        if (hit.CompareTag("Lamp")) 
        {
            Destroy(hit.gameObject);
            lampBroken = true;
            Instantiate(brokenLamp);
            InventoryManager.instance.RemoveItem(this);
        }

    }

}
