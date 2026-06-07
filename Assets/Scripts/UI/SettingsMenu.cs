using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    // TODO: Make a list of images instead?
    [SerializeField] Image volumeHandlerImage;
    [SerializeField] Image sfxHandlerImage;
    [SerializeField] Sprite budFlower;
    [SerializeField] Sprite middleFlower;
    [SerializeField] Sprite bloomFlower;

    // Note: Probably replace these completely with AudioManager methods
    public void SetVolume(float sliderValue)
    {
        AudioManager.instance.SetGlobalVolume(sliderValue);
        UpdateAnimation(volumeHandlerImage, sliderValue);
    }

    public void SetSFX(float sliderValue)
    {
        AudioManager.instance.SetGlobalSFX(sliderValue);
        UpdateAnimation(sfxHandlerImage, sliderValue);
    }

    // Handles slider flower animation
    void UpdateAnimation(Image handlerImage, float sliderValue)
    {
        if (sliderValue < 0.25)
        {
            handlerImage.sprite = budFlower;
        } 
        else if (sliderValue > 0.25 && sliderValue < 0.75)
        {
            handlerImage.sprite = middleFlower;
        } 
        else
        {
            handlerImage.sprite = bloomFlower;
        }
    }
}
