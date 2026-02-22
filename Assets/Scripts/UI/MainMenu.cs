using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string mainSceneName;
    [SerializeField] private AudioSource buttonAudioSource;

    
    public void OnButtonClick() //we may not need this if we do door opening animation
    {
        //StartCoroutine(PlayButtonSFX());
        SceneManager.LoadScene(mainSceneName);
    }

    public void OnButtonClickQuit() //we may not need this if we do door opening animation
    {
        StartCoroutine(QuitGame());
    }

    public IEnumerator PlayButtonSFX()
    {
        buttonAudioSource.Play();

        yield return new WaitForSeconds(buttonAudioSource.clip.length);
        SceneManager.LoadScene(mainSceneName);
    }
    /**public void StartGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }*/
    public IEnumerator QuitGame()
    {
        buttonAudioSource.Play();

        yield return new WaitForSeconds(buttonAudioSource.clip.length);
        Application.Quit();
    }
}
