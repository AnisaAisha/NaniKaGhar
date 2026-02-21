using UnityEngine;

public class TellerFinalForms : MonoBehaviour
{
    public FortuneTellerInteraction borrow;
    [SerializeField] GameObject NextPhase;
    [SerializeField] GameObject FinalForm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void check()
    {

        if (borrow.hmm == 1)
        {
            NextPhase.SetActive(true);
        }
        else
        {
            FinalForm.SetActive(true);
        }
    }

    // Update is called once per frame
    
}
