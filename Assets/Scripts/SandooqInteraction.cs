using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SandooqInteraction : UIInteractables
{
    [SerializeField] List<TMP_InputField> lockInputFields;
    [SerializeField] GameObject sandooqOpen;
    [SerializeField] GameObject scalesCollider;

    private bool isLockOpened;
    private bool isSandooqOpen;
    private const string correctCombo = "2699";

    void Awake()
    {
        isLockOpened = false;
        isSandooqOpen = false;
        lockInputFields = new List<TMP_InputField>(GetComponentsInChildren<TMP_InputField>());

        // add listeners on each text field to trigger a check when value changes
        foreach (TMP_InputField field in lockInputFields)
        {
            field.onValueChanged.AddListener(_ => InteractUI());
        }
    }

    public bool GetLockStatus()
    {
        return isLockOpened;
    }

    public void SetLockStatus(bool status)
    {
        isLockOpened = status;
    }

    // void Start()
    // {
        // Dialogue d = new Dialogue();
        // d.sentences = new string[] { "Looks like I need to enter 4 numbers here..." };

        // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        // dialogTrigger.TriggerDialogue(d);
    // }

    // TODO: Replace with EndInteractUI()
    public void CloseLock() {
        // Dialogue d = new Dialogue();
        // d.sentences = new string[] { "The lock opened!" };

        // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        // dialogTrigger.TriggerDialogue(d);

        // StartCoroutine(AddDelay());

        gameObject.SetActive(false);
        sandooqOpen.SetActive(true);
        scalesCollider.SetActive(true);
        DOFManager.instance.SetBackgroundBlur(false);    

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
                isLockOpened = true;
                StoryManager.instance.UpdateStoryState(StoryState.LockOpened);
                CloseLock();
            } else {
                Reset();
            }
        }
    }

    public void ChangeState()
    {
        if (isLockOpened)
        {
            isSandooqOpen = !isSandooqOpen;
            sandooqOpen.SetActive(isSandooqOpen);
        }
    }
}
