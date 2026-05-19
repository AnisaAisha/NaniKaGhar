using UnityEngine;
using UnityEngine.EventSystems;

// Objects that are interactable/non-interactable on closeup with blurred background
public class FocusedObject : Interactables
{
    [SerializeField] GameObject ObjectUIOverlay;
    public override void Interact()
    {
        // DOFManager.instance.SetBackgroundBlur(true);
        ObjectUIOverlay.SetActive(true);
        Debug.Log(name + " Game Object Clicked!");
    }

    public override void EndInteract()
    {
        ObjectUIOverlay.SetActive(false);
        // DOFManager.instance.SetBackgroundBlur(false);        
    }

    // TODO: Prevent collisions in scene when interacting with UI
}
