using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
using UnityEngine.EventSystems;

public class MagicDoor :Interactables, IPointerClickHandler
{
    [SerializeField] GameObject MagicDoorOverlay;
    [SerializeField] CinemachineCamera camera;

    const float zoomDuration = 2f;  // in seconds
    const float targetOrthoSize = 7.5f;


    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(ZoomCamera(targetOrthoSize, zoomDuration));
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (!MagicDoorOverlay.activeSelf) StartCoroutine(ZoomCamera(30f, zoomDuration));
    }

    private IEnumerator ZoomCamera(float target, float duration)
    {
        float startSize = camera.Lens.OrthographicSize;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            t = Mathf.SmoothStep(0f, 1f, t);

            camera.Lens.OrthographicSize = Mathf.Lerp(startSize, target, t);
            yield return null;
        }
        // StartCoroutine(DOFManager.instance.AnimateBlur(0.01f, 10f));
    }

    public override void Interact()
    {
        MagicDoorOverlay.SetActive(true);
        PuzzleGame.DoorOverlay = true;
        DialogueManager.instance.StartStoryDialogue("MagicDoorFirst");
    }
}
