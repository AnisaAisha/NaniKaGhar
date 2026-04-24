using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DOFManager : MonoBehaviour
{
    public static DOFManager instance { get; private set;}
    [SerializeField] Volume globalVolume;
    private float focusDistance;
    private DepthOfField dof;

    void Awake() {
        // Singleton check
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        focusDistance = 1;
        globalVolume.profile.TryGet(out dof);
    }

    // Implements background blur
    public void SetBackgroundBlur(bool toggle)
    {
        dof.active = toggle;
        dof.focusDistance.value = focusDistance;
    }
}
