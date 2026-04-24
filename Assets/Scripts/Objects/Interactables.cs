using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

// Base class for all interactable objects
public class Interactables : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("some object clicked!");
        Interact();
    }

    // Virtual function that may be overriden in child classes
    public virtual void Interact() {
        // Add dialogue manager code here
    }

    public virtual void EndInteract() {}
}
