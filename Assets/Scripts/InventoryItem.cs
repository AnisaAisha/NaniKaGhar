using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Sprite wetRag;
    public InventoryItemData itemData;
    private Vector2 originalPos;
    private Image itemImage;

    void Awake()
    {
        itemImage = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        // Debug.Log("Begin Drag...");
        originalPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging...");
        transform.position = Input.mousePosition;
        CheckHover(eventData);
    }

    public void OnEndDrag(PointerEventData eventData) {
        // Debug.Log("End Drag...");
        transform.position = originalPos;
    }

    IEnumerator AddDelay() {
        yield return new WaitForSeconds(5f);
    }

    void CheckHover(PointerEventData eventData)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        if (hit != null)
        {
            Debug.Log("Hovering over: " + hit.name);
            if (itemData.name == "rag" && hit.CompareTag("Sink")) {
                itemImage.sprite = wetRag; // Change rag icon

                // Update scriptable object for persistent storage
                itemData.icon = wetRag;
                itemData.isDry = false;

                Dialogue d = new Dialogue();
                d.sentences = new string[] { "The rag is now wet (idk pls help with this dialogue)" };

                DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
                dialogTrigger.TriggerDialogue(d);
            }
            else if (itemData.name == "rag" && itemData.isDry && hit.CompareTag("Flame")) {
                Dialogue d = new Dialogue();
                d.sentences = new string[] { "Maia: I can't use a dry cloth." };

                DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
                dialogTrigger.TriggerDialogue(d);
            }
            else if (itemData.name == "rag" && !itemData.isDry && hit.CompareTag("Flame")) {

                // Turn off the flame and smoke
                hit.gameObject.SetActive(false);
                ParticleSystem smoke = GameObject.Find("Smoke").GetComponent<ParticleSystem>();
                smoke.Stop();
                StartCoroutine(AddDelay());

                // Dialogues for Maia Room Scene
                Dialogue d = new Dialogue();
                d.sentences = new string[] { 
                    "Maia: Any later, and mamu wouldn't have had a house to claim.",
                    "Maia: It's such a shame though, the Sundrip fragrance was nani's favourite.",
                    "I must make it again to dispel the smell of burnt potion.",
                    "Actually, now that nani...isn't...or I mean she can't...see what I'm doing, I can just brew potions in the kitchen I guess.",
                    "I should gather the ingredients again."
                };

                DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
                dialogTrigger.TriggerDialogue(d);
            } else if (hit.CompareTag("Flame")) {
                Dialogue d = new Dialogue();
                d.sentences = new string[] { "Maia: I can't use this item." };

                DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
                dialogTrigger.TriggerDialogue(d);
            }
        }
    }
}