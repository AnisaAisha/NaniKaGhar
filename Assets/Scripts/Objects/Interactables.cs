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
        StoryManager.OnStateChanged += OnStoryStateChanged;
    }

    void OnDisable()
    {
        StoryManager.OnStateChanged -= OnStoryStateChanged;
    }

    // Virtual function that may be overriden in child classes
    public virtual void Interact() {
        // Add dialogue manager code here
        // Every interact function in child class will have a story state change (TBD)
    }

    public virtual void EndInteract() {}

    protected virtual void OnStoryStateChanged(StoryState newState) {}

    // NOTE: In Room1, DialogueSystem is disabled because that is over some objects and is blocking clicks
    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }
}
