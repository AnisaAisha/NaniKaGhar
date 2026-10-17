using UnityEngine;
using UnityEngine.EventSystems;

// Objects that are interactable/non-interactable on closeup with blurred background
public class FocusedObject : Interactables
{
    [SerializeField] protected GameObject ObjectUIOverlay;
    [SerializeField] protected bool Lifafa;
    [SerializeField] protected bool Notebook;
    [SerializeField] protected bool Teller;
    public override void Interact()
    {
        
        DOFManager.instance.SetBackgroundBlur(true);
        ObjectUIOverlay.SetActive(true);
        // Debug.Log(name + " Game Object Clicked!");
        if(Lifafa)
        {
            AudioManager.instance.PlaySingleSoundSFX("LifafaPickup");
        }

        if(Notebook)
        {
            AudioManager.instance.PlaySingleSoundSFX("Notebook");
        }

        if(Teller)
        {
            AudioManager.instance.PlaySingleSoundSFX("PageRustle");
        }

    }

    public override void EndInteract()
    {
        ObjectUIOverlay.SetActive(false);
        DOFManager.instance.SetBackgroundBlur(false);        
    }
}
