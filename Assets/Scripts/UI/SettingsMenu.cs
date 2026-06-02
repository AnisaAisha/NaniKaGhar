using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    // [SerializeField] Animator handleAnimator;
    // [SerializeField] private AudioSource buttonAudioSource;
    // [SerializeField] private AudioMixer mixer;
    // [SerializeField] private GameObject MainMenu;

    // TODO: Make a list of images instead?
    [SerializeField] Image volumeHandlerImage;
    [SerializeField] Image sfxHandlerImage;
    [SerializeField] Sprite budFlower;
    [SerializeField] Sprite middleFlower;
    [SerializeField] Sprite bloomFlower;

    /** TODO: Create AudioManager that handles all the BG Music/SFX 
    (this is a temporary working version to test out the sliders) 
    Probably also use PlayerPrefs to save/load audio settings in AudioManager
    */
    // public void OnButtonClick()
    // {
    //     StartCoroutine(PlayButtonSFX());
    // }

    // public IEnumerator PlayButtonSFX()
    // {
    //     buttonAudioSource.Play();

    //     yield return new WaitForSeconds(buttonAudioSource.clip.length);
    //     this.gameObject.SetActive(false);
    //     MainMenu.SetActive(true);
    // }

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
