using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SandooqInteraction : UIInteractables
{
    [SerializeField] List<TMP_InputField> lockInputFields;
    [SerializeField] GameObject sandooqOpen;
    [SerializeField] GameObject scalesCollider;

    public bool isLockOpened;
    private const string correctCombo = "2699";

    void Awake()
    {
        isLockOpened = false;
        lockInputFields = new List<TMP_InputField>(GetComponentsInChildren<TMP_InputField>());

        // add listeners on each text field to trigger a check when value changes
        foreach (TMP_InputField field in lockInputFields)
        {
            field.onValueChanged.AddListener(_ => InteractUI());
        }
    }

    // void Start()
    // {
        // Dialogue d = new Dialogue();
        // d.sentences = new string[] { "Looks like I need to enter 4 numbers here..." };

        // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        // dialogTrigger.TriggerDialogue(d);
    // }

    public void CloseLock() {
        // Dialogue d = new Dialogue();
        // d.sentences = new string[] { "The lock opened!" };

        // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        // dialogTrigger.TriggerDialogue(d);

        // StartCoroutine(AddDelay());

        gameObject.SetActive(false);
        sandooqOpen.SetActive(true);
        scalesCollider.SetActive(true);

        // if (!InventoryManager.instance.isContainScales) {
        //     sandooqOpen.SetActive(true);
        //     scalesCollider.SetActive(true);
        // }

        // StoryManager.instance.isLockOpened = true;

        // if (!InventoryManager.instance.isContainScales && StoryManager.instance.isLockOpened) {
        //     sandooqOpen.SetActive(true);
        //     scalesCollider.SetActive(true);
        // }
    }

    bool AreAllFieldsFilled()
    {
        foreach (TMP_InputField field in lockInputFields)
        {
            if (string.IsNullOrWhiteSpace(field.text))
            {
                return false;
            }
        }
        return true;
    }

    string GetCombination()
    {
        string result = "";
        foreach (var field in lockInputFields)
        {
            result += field.text;
        }
        return result;
    }

    void Reset()
    {
        foreach (var field in lockInputFields)
        {
            field.text = "";
        }
        // Dialogue d = new Dialogue();
        // d.sentences = new string[] { "The lock does not seem to open..." };

        // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        // dialogTrigger.TriggerDialogue(d);
    }

    //void Update()
    // Main Interaction of Sandooq Lock
    public override void InteractUI()
    {
        if (AreAllFieldsFilled()) 
        {
            string combo = GetCombination();
            if (combo == correctCombo) 
            {
                CloseLock();
            } else {
                Reset();
            }
        }
    }
}
