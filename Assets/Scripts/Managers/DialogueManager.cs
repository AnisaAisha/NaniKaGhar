using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set;}
    private DialogueRunner dialogueRunner;
    private LineAdvancer lineAdvancer;

    void Awake()
    {
        // Singleton check
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetDialogueRunner(DialogueRunner dr)
    {
        dialogueRunner = dr;
    }

    public void SetLineAdvancer(LineAdvancer la)
    {
        lineAdvancer = la;
    }

    public void PauseDialogue(bool isPaused)
    {
        lineAdvancer.enabled = !isPaused;
    }

    public void StartStoryDialogue(string nextScene)
    {
        dialogueRunner.StartDialogue(nextScene);
    }

    //condition allows me to run dialogue for ingredient added to potion
    public void StartItemDialogue(string itemName, bool potion)
    {
        dialogueRunner.VariableStorage.SetValue("$itemName", itemName);
        if (potion)
        {
            Debug.Log("here");
            dialogueRunner.StartDialogue("PotionAdd");
        }
        else if (!potion)
        {
            dialogueRunner.StartDialogue("InventoryItem");
        }
    }
}
