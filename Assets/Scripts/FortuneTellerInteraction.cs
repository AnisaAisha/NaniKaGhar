using UnityEngine;
using UnityEngine.Audio;
public class FortuneTellerInteraction : MonoBehaviour
{
    [SerializeField] GameObject TellerUIOverlay;
    [SerializeField] private AudioSource buttonAudioSource;
    public bool isTellerOpened;
    private int clickCount;
    public int hmm;
    public bool check;


    void Awake()
    {
        clickCount = 0;
        isTellerOpened = false;
        check = false;
    }

    /**public void CloseTeller() {
        TellerUIOverlay.SetActive(false);
    }*/

    public void OnMouseDown()
    {
        clickCount++;
        check = true;
        hmm = 0;
    }

    public void Counter()
    {
        hmm++;
    }
    void Update()
    {
        // hacky solution because apparently clicking the first time doesn't get triggered
        if (clickCount == 1) 
        {
            buttonAudioSource.Play();
            TellerUIOverlay.SetActive(true);
            isTellerOpened = true;
            clickCount = 0;
        }

    }

}
    

