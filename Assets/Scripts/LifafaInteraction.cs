using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LifafaInteraction : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject peekingLetter;
    [SerializeField] GameObject letter;
    [SerializeField] GameManager gameManager;
    [SerializeField] Image sr;
    // [SerializeField] StoryManager storyManager;

    public bool isLetterOpened;

    private int clickCount;


    void Awake()
    {
        clickCount = 0;
        isLetterOpened = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Object Clicked!");
        clickCount++;
    }

    public void CloseLetter() {
        letter.SetActive(false);
        Dialogue d = new Dialogue();
        d.sentences = new string[] { "Maia: By Sunday? But that's today. I think mamu must have mailed this earlier. It's possible the post was delayed by the rain." };

        DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
        dialogTrigger.TriggerDialogue(d);

        isLetterOpened = true;

        gameManager.SetBackgroundBlur(false);
    }

    void Update()
    {
        // hacky solution because apparently clicking the first time doesn't get triggered
        if (clickCount == 1) 
        {
            // implement peeking letter later
            // Color c = sr.color;
            // c.a = 0f;
            // sr.color = c;
            // peekingLetter.SetActive(true);
        // } 
        // else if (clickCount == 2)
        // {
            this.gameObject.SetActive(false); // Lifafa is not visible now
            // peekingLetter.SetActive(false);
            letter.SetActive(true);
            StoryManager.instance.isLetterOpened = true;
        }
    }
}
