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
<<<<<<< HEAD
        //ConversationManager.Instance.StartConversation(myConversation); //修改对话框
=======
        ConversationManager.Instance.StartConversation(myConversation); //修改对话框
>>>>>>> 5966b8b0f30ae9222c2c55427bea8e3a6a4e94f8
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
