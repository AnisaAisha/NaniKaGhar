using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    // TODO: Use a persistent system like Yarn or Ink for this after the Game Jam
    public static StoryManager instance;
    public static event System.Action<StoryState> OnStateChanged;

    // [SerializeField] StoryState[] storystate_list;
    // public Dictionary<Objective, bool> stateDict;
    private StoryState currentState;
    private int currentStateIdx; // this is the global int that drives the story states
    // private List<StoryState> states_list;
    


    public bool isPhonePicked;
    public bool isRoomDialogDone;
    public bool isLetterOpened;
    public bool isFireExtinguished;
    public bool isDiaryOpened;
    public bool isLockOpened;
    public bool isPotionReady;
    public bool doorCreakDone;
    public bool isSecondPhoneRingOnce;
    private List<string> currentIngredients;


    void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize only once
        isLetterOpened = false;
        isPhonePicked = false;
        isFireExtinguished = false;
        isDiaryOpened = false;
        isLockOpened = false;
        isPotionReady = false;
        doorCreakDone = false;
        isRoomDialogDone = false;
        currentIngredients = new List<string>();

        // storystate_list = new List<StoryState>();
        // stateDict = new Dictionary<Objective, bool>();
        // foreach (StoryState s in storystate_list) stateDict.Add(s, false);

        // InitStoryStates();
    }

    // void InitStoryStates()
    // {
    //     states_list = new List<StoryState>();

    //     // Initialize states by hard coding rn

    //     // First state: Wait for player to open letter
    //     StoryState Initial = new StoryState();
    //     Initial.AddObjective(Objective.OpenLetter, false);

    //     // Second state: Ring phone
    //     StoryState PhoneRing = new StoryState();
    //     PhoneRing.AddObjective(Objective.RingPhone, false);

    //     // Third state: Phone is picked
    //     StoryState PhonePick = new StoryState();
    //     Initial.AddObjective(Objective.PhonePicked, false);

    //     // Add all story states to list
    //     states_list.Add(Initial);
    //     states_list.Add(PhoneRing);
    //     states_list.Add(PhonePick);

    //     currentStateIdx = 0;
    //     currentState = states_list[currentStateIdx];
    // }

    public void UpdateStoryState(StoryState state)
    {
        // stateDict[stateObjective] = status;
        // if (status == true)
        // {
        //     SwitchStoryState();
        // }

        // currentState = states_list[currentStateIdx++];

        // TODO: IMPLEMENT THIS FUNCTION
        // CheckCurrentStateRequirements()

        // Just increment the state index
        currentState = state;
        currentStateIdx++;
        OnStateChanged?.Invoke(currentState);
    }

    public void AddStoveItems(string itemName) {
        currentIngredients.Add(itemName);
    }

    public List<string> GetCurrentStoveIngredients() {
        return currentIngredients;
    }

    // MAIN GAMELOOP. THIS SHOULD BE THE ONLY UPDATE IN ALL SCRIPTS
    // void Update()
    // {
    //     if (currentStateIdx == 0)
    //     {
    //         // wait for player to open letter
    //     } else if (currentStateIdx == 1)
    //     {
    //         // letter opened, ring the phone now
    //         isPhoneRingTriggered= true;
    //         StartCoroutine(RingAfterDelay(3f));
    //     }
    // }
}
