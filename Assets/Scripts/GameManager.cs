using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] Volume globalVolume;
    [SerializeField] float focusDistance;

    private DepthOfField dof;

    // Implements background blur
    public void SetBackgroundBlur(bool toggle)
    {
        if (globalVolume.profile.TryGet(out dof))
        {
            dof.active = toggle;
            dof.focusDistance.value = focusDistance;
        }
    }
}
