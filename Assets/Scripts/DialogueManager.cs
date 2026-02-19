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

     void Start()
    {
        sentences = new Queue<string>();
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
