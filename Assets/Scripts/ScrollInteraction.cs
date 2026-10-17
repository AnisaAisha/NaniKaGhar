using UnityEngine;

public class ScrollInteraction : UIInteractables
{
    // TODO: Make a general class for UI Interactables or replace this with some other class
    [SerializeField] protected GameObject ObjectUIOverlay;
    public override void InteractUI()
    {        
        ObjectUIOverlay.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        AudioManager.instance.PlaySingleSoundSFX("PageRustle");

    }

    public override void EndInteractUI()
    {
        ObjectUIOverlay.SetActive(false);
    }
}
