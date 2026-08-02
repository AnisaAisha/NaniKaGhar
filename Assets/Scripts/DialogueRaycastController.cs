using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(CanvasGroup))]
public class DialogueRaycastController : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        // Disable raycasts by default when game starts
        canvasGroup.blocksRaycasts = false;

        // Subscribe to Yarn Spinner events
        dialogueRunner.onDialogueStart.AddListener(OnDialogueStart);
        dialogueRunner.onDialogueComplete.AddListener(OnDialogueComplete);
    }

    private void OnDestroy()
    {
        dialogueRunner.onDialogueStart.RemoveListener(OnDialogueStart);
        dialogueRunner.onDialogueComplete.RemoveListener(OnDialogueComplete);
    }

    // Listeners that set blockRaycast to true/false depending on if dialogue is active
    private void OnDialogueStart()
    {
        canvasGroup.blocksRaycasts = true;
    }

    private void OnDialogueComplete()
    {
        canvasGroup.blocksRaycasts = false;
    }
}
