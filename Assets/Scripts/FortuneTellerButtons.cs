using UnityEngine;
using UnityEngine.UI;

// Class for fortune teller buttons -- may discard later
public class FortuneTellerButtons : UIInteractables 
{
    [SerializeField] ButtonRegion buttonRegion;
    [SerializeField] FortuneTeller teller;

    public override void InteractUI()
    {
        teller.OnRegionClicked(buttonRegion);
    }
}
