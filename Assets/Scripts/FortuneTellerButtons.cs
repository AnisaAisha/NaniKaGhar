using UnityEngine;
using UnityEngine.UI;

public class FortuneTellerButtons : MonoBehaviour
{
    [SerializeField] ButtonRegion buttonRegion;
    [SerializeField] FortuneTeller teller;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => teller.OnRegionClicked(buttonRegion));
    }
}
