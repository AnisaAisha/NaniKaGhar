using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleGame : Interactables
{
    public GameObject MagicDoorOverlay;
    public GameObject PuzzleOverlay;
    public GameObject PuzzleButton;
    public Sprite CompletedPuzzle;
    public static int PuzzleCounter = 0;
    public static bool DoorOverlay = false;


    protected override void OnStoryStateChanged(StoryState newState)
    {
        if (StoryManager.instance.currentState == StoryState.PuzzleUnlocked)
        {
            PuzzleOverlay.SetActive(true);
            PuzzleButton.GetComponent<Button>().enabled = true;
            Debug.Log("yayy");
        }
        else if (StoryManager.instance.currentState == StoryState.PuzzleCompleted)
        {
            PuzzleOverlay.SetActive(false);
            PuzzleButton.GetComponent<Image>().sprite = CompletedPuzzle;
            PuzzleButton.GetComponent<FadeScene>().FadeAndChangeScene();
        }
    }
}
