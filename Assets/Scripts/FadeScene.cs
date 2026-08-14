using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeScene : MonoBehaviour
{
    [SerializeField] string NewSceneName;
    [SerializeField] CanvasGroup canvasGroup;

    void Start()
    {
        // fade from black on loading a new scene
        canvasGroup.alpha = 0f;
        StartCoroutine(FadeFromBlack(1.5f));
    }

    IEnumerator FadeToBlack(float duration) {
        float t = 0;

        while (t < duration) {
            t += Time.deltaTime;
            canvasGroup.alpha = t/duration;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    public IEnumerator FadeFromBlack(float duration) {
        float t = 0;

        canvasGroup.alpha = 1;

        while (t < 1) {
            t += Time.deltaTime;
            canvasGroup.alpha = 1.0f - (t/duration);
            yield return null;
        }

        canvasGroup.alpha = 0;
    }

    IEnumerator ChangeScene() {
        yield return StartCoroutine(FadeToBlack(2f));
        SceneManager.LoadScene(NewSceneName);

        // If there are any popups open, disable DOF
        DOFManager.instance.SetBackgroundBlur(false);
    }

    public IEnumerator EndScene() {
        yield return StartCoroutine(FadeToBlack(3f));
        Application.Quit();
    }

    public void FadeAndChangeScene() {
        StartCoroutine(ChangeScene());  
    }
    void OnTriggerEnter2D(Collider2D collider) {
        // if Player is in trigger area, change scene
        if (collider.gameObject.layer == 6) {
            StartCoroutine(ChangeScene());
        }
    }
}
