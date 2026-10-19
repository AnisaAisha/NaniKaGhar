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
            AudioManager.instance.PlaySingleSoundSFX("GlassShatter");
            Destroy(hit.gameObject);
            lampBroken = true;
            Debug.Log(lampBroken);
            Instantiate(brokenLamp);
            InventoryManager.instance.RemoveItem(this);
        }

    }

}
