using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] FadeScene fadeSceneScript;

    void Start()
    {
        StartCoroutine(fadeSceneScript.FadeOut(2f));
    }
}
