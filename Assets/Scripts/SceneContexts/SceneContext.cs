using UnityEngine;
using Yarn.Unity;

// Initialize and handle all game objects that may be relevant for difference scenes
public class SceneContext : MonoBehaviour
{
    [SerializeField] public DialogueRunner dialogueRunner;
    [SerializeField] ParticleSystem smoke;

     void Awake()
    {
        GameManager.instance.SetSceneContext(this); // Send game manager scene info directly
    }

    // Scene specific logic inside OnSceneReady
    public virtual void OnSceneReady(){}

    protected void HandleSmoke()
    {
        if (StoryManager.instance.storyStates[StoryState.PhonePicked] &&
           !StoryManager.instance.storyStates[StoryState.ExtinguishFlame])
        {
            smoke?.Play();
        }
    }
}