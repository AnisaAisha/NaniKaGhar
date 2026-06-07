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

    public void StartItemDialogue(string itemName)
    {
        dialogueRunner.VariableStorage.SetValue("$itemName", itemName);
        dialogueRunner.StartDialogue("InventoryItem");
    }
}
