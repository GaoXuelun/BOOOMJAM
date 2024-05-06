using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;   //修改

public class Box : MonoBehaviour, InteractableInterface
{
    public NPCConversation myConversation; //修改 
    [SerializeField] private string interactText;
    public void TriggerAction()
    {
        Debug.Log("box");
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
