using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

 public enum ButtonRegion
{
    Topleft,
    Topright,
    Bottomleft,
    Bottomright
}
public class FortuneTeller : UIInteractables
{
    public enum FortuneTellerState
    {
        Initial,
        Phase1,  // 1357
        Phase2,   //20 14 10 8
        FinalPhaseWin,
        FinalPhaseTry,
        FinalPhaseD,
        FinalPhaseNum
    }

    [SerializeField] Image currentImage;
    [SerializeField] Sprite[] stateSprites; // WARNING: IMAGE LIST ON INSPECTOR SHOULD BE IN SAME ORDER AS ENUMS

    private FortuneTellerState currentState;
    private int currentStep;

    void Awake()
    {
        ResetState();
    }
    public void OnRegionClicked(ButtonRegion region)
    {
        if (currentState == FortuneTellerState.Initial)
        {
            if (region == ButtonRegion.Bottomleft)
            {
                SwitchState(FortuneTellerState.Phase1);
            } else
            {
                SwitchState(FortuneTellerState.Phase2);
            }
        } else if (currentState == FortuneTellerState.Phase1 && currentStep == 1)
        {
            SwitchState(FortuneTellerState.Phase2);
        } else if (currentState == FortuneTellerState.Phase2 && currentStep == 1)
        {
            SwitchState(FortuneTellerState.Phase1);
        } else if (currentState == FortuneTellerState.Phase2 && currentStep == 2)
        {
            if (region == ButtonRegion.Bottomleft || region == ButtonRegion.Topleft)
            {
                SwitchState(FortuneTellerState.FinalPhaseWin);
            } else
            {
                SwitchState(FortuneTellerState.FinalPhaseTry);
            }
        } else if (currentState == FortuneTellerState.Phase1 && currentStep == 2)
        {
            if (region == ButtonRegion.Bottomleft || region == ButtonRegion.Topleft)
            {
                SwitchState(FortuneTellerState.FinalPhaseD);
            } else
            {
                SwitchState(FortuneTellerState.FinalPhaseNum);
            }
        }
        currentStep++;
    }

    // switch state and image of fortune teller
    void SwitchState(FortuneTellerState state)
    {
        currentState = state;
        currentImage.sprite = stateSprites[(int)state];
    }

    // reset to initial state
    void ResetState()
    {
        currentStep = 0;
        SwitchState(FortuneTellerState.Initial);
    }

    public override void EndInteractUI()
    {
        gameObject.SetActive(false);
        DOFManager.instance.SetBackgroundBlur(false); 
        ResetState();
    }
}
    

