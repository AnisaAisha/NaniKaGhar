using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInteractables : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked a UI object!!");
        InteractUI();
    }

    public virtual void InteractUI() {
        // Add dialogue manager code here
    }
    public virtual void EndInteractUI() {}
}
