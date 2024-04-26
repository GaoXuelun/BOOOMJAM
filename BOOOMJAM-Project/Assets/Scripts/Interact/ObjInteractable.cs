using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractable : MonoBehaviour, Interactable
{
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
