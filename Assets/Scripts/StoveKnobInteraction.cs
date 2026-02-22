using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class StoveKnobInteraction : MonoBehaviour
{
    [SerializeField] AudioSource doorCreakSFX;
    [SerializeField] ParticleSystem purpleHaze;
    [SerializeField] GameObject stoveFlame;
    private string[] reqIngredients;
    private bool isStoveReady;
    
    void Awake() {
        isStoveReady = false;
        reqIngredients = new string[] { "Jalpari Scales", "ChinarBark", "DriedApricot", "Bougainvillea" };
    }

    bool CheckStoveIngredients() {
        List<string> inventoryIngredients = StoryManager.instance.GetCurrentStoveIngredients();
        Debug.Log(inventoryIngredients.Count);
        Debug.Log(reqIngredients.Length);
        if (inventoryIngredients.Count == reqIngredients.Length) {
            for (int i = 0; i < reqIngredients.Length; i++) {
                // Debug.Log(inventoryIngredients[i] + " " + reqIngredients[i]);
                if (!reqIngredients.Contains(inventoryIngredients[i])) {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    void OnMouseDown()
    {
        bool isStoveReady = CheckStoveIngredients();
        if (isStoveReady) {
            stoveFlame.SetActive(true);
            purpleHaze.Play();

            Dialogue d = new Dialogue();
            DialogueTrigger dialogTrigger = gameObject.AddComponent<DialogueTrigger>();
            d.sentences = new string[] {  
                "Maia: This fragrance reminds me of nani. She loves it.",
                "Maia: She would try to guess its notes, nagging me to tell her what was the one she couldn't place.",
                "Maia: She used to say there was something magical about it.",
                "Maia: If only I could tell her..",
                "Maia: Which reminds me, she never told me what the secret ingredient in her Khaplu-famous momos was.",
                "Maia: What was that sound?"
            };
            dialogTrigger.TriggerDialogue(d);

            StoryManager.instance.isPotionReady = true;

            dialogTrigger.SetDialogueInteraction(1, "delay");
            dialogTrigger.SetDialogueInteraction(2, doorCreakSFX);

            StoryManager.instance.doorCreakDone = true;
        }
    }
}
