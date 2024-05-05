using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour, InteractableInterface
{
    public Vector3 positionToGo;
    
    public void TriggerAction()
    {
        Debug.Log("Door to next");
    }

}
