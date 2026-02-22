using UnityEngine;

public class CourtyardInteraction : MonoBehaviour
{
    [SerializeField] GameObject magicDoor;

    void Start()
    {
        if (StoryManager.instance.doorCreakDone) {
            magicDoor.SetActive(true);
        }
    }
}
