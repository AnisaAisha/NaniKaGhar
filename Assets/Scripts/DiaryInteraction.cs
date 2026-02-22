using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class DiaryInteraction : MonoBehaviour
{
    [SerializeField] GameObject diaryUIOverlay;
    [SerializeField] private AudioSource buttonAudioSource;
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
        buttonAudioSource.Play();
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
