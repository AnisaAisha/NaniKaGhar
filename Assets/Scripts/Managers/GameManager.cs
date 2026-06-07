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

    void Start()
    {
        // Start BG music as the game starts
        AudioManager.instance.PlayMainMusic("BGTheme");
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

        // DialogueManager.instance.dialogueRunner.timeScale = false;
        
        // TODO: Move this code to inventory manager, temp fix
        // Initialize and rebuild inventory panel on every scene load
        if (scene.name != "MainMenu") InventoryManager.instance.InitializeInventoryPanel();
    }

    // Scene specific interaction handled by each scene's own context class
    public void SetSceneContext(SceneContext context)
    {
        // currentContext = context;
        DialogueManager.instance.SetDialogueRunner(context.dialogueRunner); //context.dialogueRunner;
        DialogueManager.instance.SetLineAdvancer(context.lineAdvancer); //context.lineAdvancer;
        context.OnSceneReady();
    }
}
