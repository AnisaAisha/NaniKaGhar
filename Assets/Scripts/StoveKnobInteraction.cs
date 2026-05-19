using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class StoveKnobInteraction : Interactables
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
        if (isStoveReady) {
            stoveFlame.SetActive(true);
            purpleHaze.Play();

            // Dialogue d = new Dialogue();
            // DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
            // d.sentences = new string[] {  
            //     "Maia: This fragrance reminds me of nani. She loves it.",
            //     "Maia: She would try to guess its notes, nagging me to tell her what was the one she couldn't place.",
            //     "Maia: She used to say there was something magical about it.",
            //     "Maia: If only I could tell her..",
            //     "Maia: Which reminds me, she never told me what the secret ingredient in her Khaplu-famous momos was.",
            //     "Maia: What was that sound?"
            // };
            // dialogTrigger.TriggerDialogue(d);

            // StoryManager.instance.isPotionReady = true;

            // dialogTrigger.SetDialogueInteraction(1, "delay");
            // dialogTrigger.SetDialogueInteraction(2, doorCreakSFX);

            // StoryManager.instance.doorCreakDone = true;
        }
    }
}
