using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;   //èCâ¸

public class Switch : MonoBehaviour, InteractableInterface
{
    public NPCConversation myConversation; //èCâ¸ 
    [SerializeField] private string interactText;
    [SerializeField] private Light pointLight;

    private void Start()
    {
        // Ensure the light is initially off
        pointLight.enabled = false;
    }

    public void TriggerAction()
    {
        if (!pointLight.enabled)
        {
            pointLight.enabled = true;
            Debug.Log("Light has been turned on.");
        }
        ConversationManager.Instance.StartConversation(myConversation);

        Destroy(GetComponent<BoxCollider>());
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
