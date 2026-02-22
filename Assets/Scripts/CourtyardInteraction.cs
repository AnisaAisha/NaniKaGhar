using UnityEngine;
using UnityEngine.Audio;

public class CourtyardInteraction : MonoBehaviour
{
    [SerializeField] GameObject magicDoor;
    [SerializeField] ParticleSystem smoke;
    [SerializeField] AudioSource smokeSound;

    void Start()
    {
        if (!StoryManager.instance.isFireExtinguished && StoryManager.instance.isPhonePicked) {
            smoke.Simulate(4f, true, true, true); // prewarm particle system
            smoke.Play();
            smokeSound.Play();
        }
        if (StoryManager.instance.doorCreakDone) {
            magicDoor.SetActive(true);
        }
    }
}
