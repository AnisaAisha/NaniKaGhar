using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class StoveKnob : Interactables
{
    // [SerializeField] AudioSource doorCreakSFX;
    [SerializeField] ParticleSystem purpleHaze;
    [SerializeField] GameObject stoveFlame;
    private string[] reqIngredients;
    private bool isStoveReady;
    
    void Awake() {
        isStoveReady = false;
        // CAREFUL ABOUT SPELLINGS HERE, also separate out in a constants/config file
        reqIngredients = new string[] { "Jalpari Scales", "Chinar Bark", "Dried Apricot", "Bougainvillea" };  
    }

    bool CheckStoveIngredients() {
        List<string> inventoryIngredients = StoryManager.instance.GetCurrentStoveIngredients();
        // Debug.Log(inventoryIngredients.Count);
        // Debug.Log(reqIngredients.Length);
       
        var set1 = new HashSet<string>(inventoryIngredients.ToArray());
        bool areSame = set1.SetEquals(reqIngredients);

        return areSame;
    }

    public override void Interact()
    {
        bool isStoveReady = CheckStoveIngredients();
        if (isStoveReady && StoryManager.instance.currentState == StoryState.SecondCallPicked) {
            stoveFlame.SetActive(true);
            purpleHaze.Play();

            StoryManager.instance.UpdateStoryState(StoryState.PotionSuccess);
            DialogueManager.instance.StartStoryDialogue("PotionSuccess");
        }
    }
}
