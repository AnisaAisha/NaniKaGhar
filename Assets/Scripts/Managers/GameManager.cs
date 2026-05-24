using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set;}

    void Awake() {
        // Singleton check
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return; // IMPORTANT: stop execution
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /** 
        Scene loding and scene context changes
    */
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded " + scene.name);
        
        // Initialize and rebuild inventory panel on every scene load
        InventoryManager.instance.InitializeInventoryPanel();
    }

    // Scene specific interaction handled by each scene's own context class
    public void SetSceneContext(SceneContext context)
    {
        // currentContext = context;
        DialogueManager.instance.dialogueRunner = context.dialogueRunner;
        context.OnSceneReady();
    }
}
