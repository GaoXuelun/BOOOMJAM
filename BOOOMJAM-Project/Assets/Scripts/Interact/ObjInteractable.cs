using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;   //修改

public class ObjInteractable : MonoBehaviour, Interactable
{
    public NPCConversation myConversation; //修改 
    [SerializeField] private string interactText;
    private void Start()
    {   
    }

    private void Update()
    {

    }

    public void Interact()
    {
        Debug.Log("Interact");
        ConversationManager.Instance.StartConversation(myConversation); //修改对话框
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
