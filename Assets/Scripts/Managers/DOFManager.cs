using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
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

    public IEnumerator AnimateBlur(float target, float duration)
    {
        dof.active = true;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            t = Mathf.SmoothStep(0f, 1f, t);

            dof.focusDistance.value = Mathf.Lerp(dof.focusDistance.value, target, t);
            yield return null;
        }
    }
}
