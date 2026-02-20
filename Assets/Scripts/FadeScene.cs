using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeScene : MonoBehaviour
{
    [SerializeField] bool isStaticScene;
    [SerializeField] Image image;
    [SerializeField] string NewSceneName;

    IEnumerator FadeIn(float duration) {
        float t = 0;
        Color c = image.color;
        while (t < duration) {
            t += Time.deltaTime;
            c.a = t/duration;
            image.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float duration) {
        float t = 0;
        Color c = image.color;
        while (t < 1) {
            t += Time.deltaTime;
            c.a = 1.0f - (t/1f);
            image.color = c;
            yield return null;
        }
    }

    IEnumerator ChangeScene() {
        StartCoroutine(FadeIn(2f));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(NewSceneName);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6) {
            StartCoroutine(ChangeScene());
        }
    }

    void OnMouseDown() {
        if (isStaticScene) {
            StartCoroutine(ChangeScene());
        }  
    }
}
