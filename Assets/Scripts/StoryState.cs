using UnityEngine;
using System.Collections.Generic;

public enum StoryState
{
    Initial,
    LetterOpened,
    RingPhone,
    PhonePicked,
    ExtinguishFlame
}

// [System.Serializable]
// public class StoryState 
// {
//     public string name;
//     // public Objective stateObjective;
//     // public bool status;

//     // public StateObjectives[] state_obj_list;

//     public Dictionary<Objective, bool> storyStates;

//     // public bool isLetterOpened;
//     // public bool isFirstCallPicked;
//     // public bool isFlameExtinguished;

//     public StoryState()
//     {
//         storyStates = new Dictionary<Objective,bool>();
//         // state_obj_list = new List<StateObjectives>();
//     }

//     public void AddObjective(Objective obj, bool status)
//     {
//         storyStates[obj] = status;
//     }

//     public bool GetStateStatus()
//     {
//         foreach (bool val in storyStates.Values)
//         {
//             if (!val) return false; // Exit early if any value is false
//         }
//         return true; 
//     }

// }