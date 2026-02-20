using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class Dialogue 
{
    [TextArea(3,10 )]
    public string[] sentences;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] Queue<string> sentences;

    private Dictionary<int, object> interactionList;
    private int sentenceCounter;

    public bool dialogInteraction;

     void Awake()
    {
        sentenceCounter = 0;
        dialogInteraction = false;
        sentences = new Queue<string>();
        interactionList = new Dictionary<int, object>();
    }

    public void StartDialogue(Dialogue dialogue) {
       sentences.Clear();

       foreach (string sentence in dialogue.sentences) 
       {
        sentences.Enqueue(sentence);
       } 
       DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            return;
        }
        string sentence = sentences.Dequeue();
        sentenceCounter++;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (dialogInteraction) {
            StartDialogueInteraction();
        }
    }

    IEnumerator TypeSentence(string sentence) {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void SetDialogueInteraction(int dialogIndex, object item) {
        interactionList.Add(dialogIndex, item);
    }

    private void StartDialogueInteraction() {
        Debug.Log(sentences.Count);

        foreach (var pair in interactionList)
        {
            int i = pair.Key;
            object item = pair.Value;

            if (sentences.Count == i) {
                if (item is AudioSource audio) {
                    audio.Play();
                } else if (item is ParticleSystem ps) {
                    ps.Play();
                }
            }
        }
    }
}
