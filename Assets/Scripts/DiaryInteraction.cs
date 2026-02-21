using UnityEngine;

public class DiaryInteraction : MonoBehaviour
{
    [SerializeField] GameObject diaryUIOverlay;

    public bool isDiaryOpened;
    private int clickCount;


    void Awake()
    {
        clickCount = 0;
        isDiaryOpened = false;
    }

    public void CloseDiary() {
        diaryUIOverlay.SetActive(false);
        clickCount++;
    }

    public void OnMouseDown()
    {
        clickCount++;
    }

    void Update()
    {
        // hacky solution because apparently clicking the first time doesn't get triggered
        if (clickCount == 1) 
        {
            diaryUIOverlay.SetActive(true);
            isDiaryOpened = true;
            StoryManager.instance.isDiaryOpened = true;
        }
    }
}
