using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/FadeEventSO")]
public class FadeEventSO : ScriptableObject
{
    public UnityAction<Color, float, bool> OnEventRaised;
    public void FadeIn(float duration)  // be dark
    {
        RaiseEvent(Color.black, duration, true);
    }

    public void FadeOut(float duration) // be transparent
    {
        RaiseEvent(Color.clear, duration, false);        
    }

    public void RaiseEvent(Color target, float duration, bool fadeIn)
    {
        OnEventRaised?.Invoke(target, duration, fadeIn);
    }
}
