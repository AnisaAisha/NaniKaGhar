using UnityEngine;

public class SandooqColliderInteraction : MonoBehaviour
{
    [SerializeField] GameObject sandooqUIOverlay;
    [SerializeField] GameObject sandooqOpen;
    [SerializeField] GameObject scalesCollider;

    public void CloseSandooq() {
        sandooqUIOverlay.SetActive(false);
    }

    public void OnMouseDown()
    {
        sandooqUIOverlay.SetActive(true);
    }
}
