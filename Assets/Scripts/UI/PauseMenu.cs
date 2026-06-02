using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    private bool isPaused;

    void Start()
    {
        isPaused = false;
        LoadSliderValues();
    }

    // TODO: Remove Update if possible
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            // buttonAudioSource.Play();
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Freeze game time
        isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    void LoadSliderValues()
    {
        // sync sliders to current AudioManager values when menu opens
        musicSlider.value = AudioManager.instance.GetGlobalVolume();
        sfxSlider.value = AudioManager.instance.GetGlobalSFX();
    }
}
