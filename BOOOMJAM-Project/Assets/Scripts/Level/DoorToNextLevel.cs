using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour, InteractableInterface
{
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO sceneToGo;
    public Vector3 positionToGo;
    
    public void TriggerAction()
    {
        Debug.Log("Door to next");
        loadEventSO.RaiseLoadRequestEvent(sceneToGo, positionToGo, true);
    }

}
