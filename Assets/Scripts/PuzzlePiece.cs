using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    public GameObject slot;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        rectTransform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Reset transparency

        if (Mathf.Abs(rectTransform.anchoredPosition.x - slot.GetComponent<RectTransform>().anchoredPosition.x) <= 20f &&
        Mathf.Abs(rectTransform.anchoredPosition.y - slot.GetComponent<RectTransform>().anchoredPosition.y) <= 20f)
        {
            rectTransform.anchoredPosition = slot.GetComponent<RectTransform>().anchoredPosition;
        }
        if (rectTransform.anchoredPosition != slot.GetComponent<RectTransform>().anchoredPosition)
        {
            canvasGroup.blocksRaycasts = true; // Restore raycast blocking
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
         canvasGroup.alpha = 0.7f; // Make item slightly transparent
    }
}
