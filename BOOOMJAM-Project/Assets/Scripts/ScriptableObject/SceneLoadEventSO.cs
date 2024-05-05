using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad, Vector3 posToGo, bool fadeScreen)
    {
        //  locationToLoad: scene to load
        //  posToGo: player target position
        //  fadeScreen: fade load or not
        LoadRequestEvent?.Invoke(locationToLoad, posToGo,fadeScreen);
    }
}
