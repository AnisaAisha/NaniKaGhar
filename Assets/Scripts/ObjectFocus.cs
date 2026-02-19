using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectFocus : MonoBehaviour
{
    [SerializeField] GameObject LifafaUI;
    [SerializeField] GameManager gameManager;

    public void OnMouseDown()
    {
        gameManager.SetBackgroundBlur(true);
        LifafaUI.SetActive(true);
        Debug.Log(name + " Game Object Clicked!");
    }
}
