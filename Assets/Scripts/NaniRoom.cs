using UnityEngine;

public class NaniRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        DialogueManager.instance.StartStoryDialogue("NaniRoom");
    }
}
