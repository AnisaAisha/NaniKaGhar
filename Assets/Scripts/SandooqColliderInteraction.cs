using UnityEngine;
using UnityEngine.Audio;

public class SandooqColliderInteraction : MonoBehaviour
{
    [SerializeField] GameObject sandooqUIOverlay;
    [SerializeField] GameObject sandooqOpen;
    [SerializeField] GameObject scalesCollider;
    [SerializeField] private AudioSource buttonAudioSource;
    

    public void CloseSandooq() {
        sandooqUIOverlay.SetActive(false);
    }

    public void OnMouseDown()
    {
        buttonAudioSource.Play();
        sandooqUIOverlay.SetActive(true);
    }
}
