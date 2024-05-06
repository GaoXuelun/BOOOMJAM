using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;   //èCâ¸

public class DoorToNextLevel : MonoBehaviour, InteractableInterface
{
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO sceneToGo;
    public Vector3 positionToGo;
    public NPCConversation myConversation; //èCâ¸ 
    [SerializeField] private string interactText;

    public void TriggerAction()
    {
        Debug.Log("Door to next");
        loadEventSO.RaiseLoadRequestEvent(sceneToGo, positionToGo, true);
    }
    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
