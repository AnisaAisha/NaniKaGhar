using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    // TODO: Use a persistent system like Yarn or Ink for this after the Game Jam
    public static StoryManager instance;

    public bool isPhonePicked;
    public bool isRoomDialogDone;
    public bool isLetterOpened;
    public bool isFireExtinguished;
    public bool isDiaryOpened;
    public bool isLockOpened;
    public bool isPotionReady;
    public bool doorCreakDone;

    private List<string> currentIngredients;

    void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize only once
        isLetterOpened = false;
        isPhonePicked = false;
        isFireExtinguished = false;
        isDiaryOpened = false;
        isLockOpened = false;
        isPotionReady = false;
        doorCreakDone = false;
        isRoomDialogDone = false;
        currentIngredients = new List<string>();
    }

    public void AddStoveItems(string itemName) {
        currentIngredients.Add(itemName);
    }

    public List<string> GetCurrentStoveIngredients() {
        return currentIngredients;
    }

}
