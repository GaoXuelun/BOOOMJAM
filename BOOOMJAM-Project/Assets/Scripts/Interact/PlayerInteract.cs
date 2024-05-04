using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interact Setting")]
    [SerializeField] private float interactRange = 1.0f;

    private void Start()
    {   
    }

    private void Update()
    {   
                //修改添加if检查是否有可交互的对象，并且对话框不活动时检查交互操作
        CheckInteractObj();
        
    }

    private void CheckInteractObj()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable interactable = GetInteractableObj();
            if (interactable != null) interactable.Interact();;
        }
    }

    public Interactable GetInteractableObj()
    {
        List<Interactable> objInteractableList = new List<Interactable>();
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out Interactable interactable))
            {
                objInteractableList.Add(interactable);
                //return interactable;
            }
        }
        Interactable closestInteractable = null;
        foreach (Interactable interactable in objInteractableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))  
                    {
                        closestInteractable = interactable;
                    }  
            }
        }
        return closestInteractable;
    }
}
