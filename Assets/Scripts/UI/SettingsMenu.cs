using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioSource buttonAudioSource;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private GameObject MainMenu;

    /** TODO: Create AudioManager that handles all the BG Music/SFX 
    (this is a temporary working version to test out the sliders) 
    Probably also use PlayerPrefs to save/load audio settings in AudioManager
    */
    public void OnButtonClick()
    {
        StartCoroutine(PlayButtonSFX());
    }

    public IEnumerator PlayButtonSFX()
    {
        buttonAudioSource.Play();

        yield return new WaitForSeconds(buttonAudioSource.clip.length);
        this.gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }

    // Note: Probably replace these completely with AudioManager methods
    public void SetVolume(float sliderValue)
    {
        AudioManager.instance.SetGlobalVolume(sliderValue);
    }

    public void SetSFX(float sliderValue)
    {
        AudioManager.instance.SetGlobalSFX(sliderValue);
    }
}
