using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Audio;

public class SandooqInteraction : MonoBehaviour
{
    [SerializeField] List<TMP_InputField> lockInputFields;
    [SerializeField] GameObject sandooqOpen;
    [SerializeField] GameObject scalesCollider;
    [SerializeField] private AudioSource buttonAudioSource;
    [SerializeField] private AudioSource buttonAudioSource2;
    public bool isLockOpened;
    private const string correctCombo = "2699";

    void Awake()
    {
        isLockOpened = false;
        lockInputFields = new List<TMP_InputField>(GetComponentsInChildren<TMP_InputField>());
    }

    IEnumerator AddDelay() {
        yield return new WaitForSeconds(5f);
    }

    public void CloseLock() {
        
        buttonAudioSource.Play();
        Dialogue d = new Dialogue();
        d.sentences = new string[] { "The lock opened!" };

        DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        dialogTrigger.TriggerDialogue(d);

        StartCoroutine(AddDelay());

        gameObject.SetActive(false);
        StoryManager.instance.isLockOpened = true;

        if (!InventoryManager.instance.isContainScales && StoryManager.instance.isLockOpened) {
            buttonAudioSource2.Play();
            sandooqOpen.SetActive(true);
            scalesCollider.SetActive(true);
        }
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
        Dialogue d = new Dialogue();
        d.sentences = new string[] { "The lock does not seem to open..." };

        DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        dialogTrigger.TriggerDialogue(d);
    }

    void Update()
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
