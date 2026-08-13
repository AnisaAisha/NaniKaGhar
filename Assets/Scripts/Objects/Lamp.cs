using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

// Objects that are interactable/non-interactable on closeup with blurred background
public class Lamp : Interactables
{
    public GameObject brokenLamp;
    public override void Interact()
    {
        DialogueManager.instance.StartStoryDialogue("Lamp");
        // Debug.Log(name + " Game Object Clicked!");


    }

}
