using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;   //C‰ü
public class Bed : MonoBehaviour, InteractableInterface
{
    public NPCConversation myConversation; //C‰ü 
    [SerializeField] private string interactText;
    public void TriggerAction()
    {
        Debug.Log("Bed");
        ConversationManager.Instance.StartConversation(myConversation);
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
