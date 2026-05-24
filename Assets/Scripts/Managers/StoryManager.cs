using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryManager : MonoBehaviour
{
    // TODO: Use a persistent system like Yarn or Ink for this after the Game Jam
    public static StoryManager instance;
    public static event System.Action<StoryState> OnStateChanged;
    public Dictionary<StoryState, bool> storyStates;
    public StoryState currentState;



    private int currentStateIdx; // this is the global int that drives the story states
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
        currentIngredients = new List<string>();

        // storystate_list = new List<StoryState>();
        storyStates= new Dictionary<StoryState, bool>();

        // Initialize a list of states that have bool value assigned if that event has happened
        foreach (StoryState state in System.Enum.GetValues(typeof(StoryState)))
        {
            storyStates[state] = false;
        }

        // Set initial state to true
        storyStates[StoryState.Initial] = true;
    }

    public void UpdateStoryState(StoryState state)
    {
        storyStates[state] = true;
        
        currentState = state; // Change current state

        // Invoke event for certain events that are time based e.g. phone rings
        OnStateChanged?.Invoke(currentState);

        // DEBUG CODE: remove later
        foreach (KeyValuePair<StoryState,bool> kvp in storyStates)
        {
            Debug.Log(kvp.Key + " " + kvp.Value);
        }
    }
    //     // stateDict[stateObjective] = status;
    //     // if (status == true)
    //     // {
    //     //     SwitchStoryState();
    //     // }

    //     // currentState = states_list[currentStateIdx++];

    //     // TODO: IMPLEMENT THIS FUNCTION
    //     // CheckCurrentStateRequirements()

    //     // Just increment the state index
    //     currentState = state;
    //     currentStateIdx++;
    //     OnStateChanged?.Invoke(currentState);
    // }

    public void AddStoveItems(string itemName) {
        currentIngredients.Add(itemName);
    }

    public List<string> GetCurrentStoveIngredients() {
        return currentIngredients;
    }
}
