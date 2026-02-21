using UnityEngine;

public class ScrollInteraction : MonoBehaviour
{
    [SerializeField] GameObject willUIOverlay;

    void OnMouseDown() {
        willUIOverlay.SetActive(true);
        gameObject.SetActive(false);
    }
}
