using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Audio;

public class InventoryItem : UIInteractables, IBeginDragHandler, IDragHandler, IEndDragHandler //MonoBehaviour
{
    public InventoryItemData itemData; // ScriptableObject with InventoryItem info
    private Vector2 originalPos;
    private Image itemImage;
    private PointerEventData currentEventData;

    void Awake()
    {
        itemImage = GetComponent<Image>();
    }

    // If needed, drag functions will be moved out to UI Interactables class in future. Rn it is only specific to inventory items
    public void OnBeginDrag(PointerEventData eventData) {
        originalPos = transform.position;
        //This allows dry rag hint to reappear everytime player tries using it on flame but only once per drag
        if (itemData is Rag rag && !rag.isStateChanged)
        {
            rag.hitOnce = false;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
        // CheckHover(eventData);
        currentEventData = eventData;
        InteractUI();
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.position = originalPos;
    }

    public override void InteractUI()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(currentEventData.position);
        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        if (hit != null)
        {
            Debug.Log("checking if we hit smth...");
            itemData.InventoryItemInteract(hit);

            // Type check and then change image. NOTE: Move these fields to base class later if more objects need this field
            if (itemData is Rag rag && rag.isStateChanged)
            {
                itemImage.sprite = rag.changedIcon;
            }
        }
    }

    // void CheckHover(PointerEventData eventData)
    // {
    //     Vector2 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
    //     Collider2D hit = Physics2D.OverlapPoint(worldPos);

    //     if (hit != null)
    //     {
    //         Debug.Log("Hovering over: " + hit.name);
            // Dialogue d = new Dialogue();
            // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
            // if (!itemData.isPotionIngredient && hit.CompareTag("Stove")) {
            //     d.sentences = new string[] { "I cannot add this to the pot." };
            //     dialogTrigger.TriggerDialogue(d);
            // }
            // else if (itemData.name == "Dry Rag" && hit.CompareTag("Sink")) {
            //     itemImage.sprite = itemData.changedIcon; // Change rag icon to wet

            //     // Update scriptable object for persistent storage
            //     itemData.icon = itemData.changedIcon;
            //     itemData.isDry = false;

            //     // d.sentences = new string[] { "The rag is now drenched in water. Maybe this can put out the fire..." };
            //     // dialogTrigger.TriggerDialogue(d);
            // }
            // else if (itemData.name == "Dry Rag" && itemData.isDry && hit.CompareTag("Flame")) {
            //     d.sentences = new string[] { "Maia: I can't use a dry cloth." };
            //     dialogTrigger.TriggerDialogue(d);
            // }
            // else if (itemData.name == "Dry Rag" && !itemData.isDry && hit.CompareTag("Flame")) {
            //     StoryManager.instance.isFireExtinguished = true;
            //     // Turn off the flame and smoke
            //     hit.gameObject.SetActive(false);
            //     ParticleSystem smoke = GameObject.Find("Smoke").GetComponent<ParticleSystem>();
            //     AudioSource crackling = GameObject.Find("Smoke").GetComponent<AudioSource>();
            //     smoke.Stop();
            //     crackling.Stop();
            //     StartCoroutine(AddDelay());

            //     DialogueManager.instance.StartStoryDialogue("Potion");

                // Dialogues for Maia Room Scene
                // d.sentences = new string[] { 
                //     "Maia: Any later, and mamu wouldn't have had a house to claim.",
                //     "Maia: It's such a shame though, the Sundrip fragrance was nani's favourite.",
                //     "I must make it again to dispel the smell of burnt potion.",
                //     "Actually, now that nani...isn't...or I mean she can't...see what I'm doing, I can just brew potions in the kitchen I guess.",
                //     "I should gather the ingredients again."
                // };
                // dialogTrigger.TriggerDialogue(d);
            // else if (hit.CompareTag("Flame")) {
            //     d.sentences = new string[] { "Maia: I can't use this item." };
            //     dialogTrigger.TriggerDialogue(d);
            // } 
            // else if (hit.CompareTag("Stove")) {
            //     // Debug.Log(itemData);
            //     // Debug.Log(itemData.name);
            //     // Debug.Log(gameObject.name);
            //     d.sentences = new string[] {  $"{itemData.name} added to the pot!", };
            //     dialogTrigger.TriggerDialogue(d);
            //     // StoryManager.instance.AddStoveItems(itemData.name);
            //     InventoryManager.instance.RemoveItem(itemData);
            // }
        // }
    // }
}