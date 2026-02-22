using UnityEngine;
using UnityEngine.UI;

public class SmoothFollowCamera2D : MonoBehaviour
{

    public Image MainMenu;
    public bool time;
    public Button PlayButton;

    void Start()
    {
        // Get the Button component and add a listener to the OnClick event
        Button btn = PlayButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        time = true;
    }

     void Update()
    {
        if (time)
        {
            MainMenu.rectTransform.anchoredPosition = Vector2.Lerp(MainMenu.rectTransform.anchoredPosition, new Vector2(-1100,0), Time.deltaTime);
        }
    } 

   
}

    

