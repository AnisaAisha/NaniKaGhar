using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

// Base class for all interactable objects
public class Interactables : MonoBehaviour, IPointerClickHandler
{
    // Used AI for thse two functions --- need to verify why
    void OnEnable() 
    {
        StoryManager.OnStoryStateChanged += OnStoryStateChanged;
    }

    void OnDisable()
    {
        StoryManager.OnStoryStateChanged -= OnStoryStateChanged;
    }

    // Virtual function that may be overriden in child classes
    public virtual void Interact() {
        // Add dialogue manager code here
        // Every interact function in child class will have a story state change (TBD)
    }

    public virtual void EndInteract() {}

    // All interactables listen to story state change
    protected virtual void OnStoryStateChanged(StoryState newState) {}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("checking pointer clickk....");
        Interact();
    }
}
