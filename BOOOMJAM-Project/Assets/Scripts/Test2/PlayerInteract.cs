using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interact Setting")]
    [SerializeField] private float _interactRange = 2.0f;

    private Collider[] _colliderArray;

    private void Start()
    {   
    }

    private void Update()
    {
        CheckInteractObj();
    }



    private void CheckInteractObj()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _colliderArray = Physics.OverlapSphere(transform.position, _interactRange);
            foreach (Collider collider in _colliderArray)
            {
                //Debug.Log(collider);
                if (collider.TryGetComponent(out ObjInteractable objInteractable))
                {
                    objInteractable.ObjInteract();
                }

            }
        }
    }

    public ObjInteractable GetInteractableObj()
    {
        _colliderArray = Physics.OverlapSphere(transform.position, _interactRange);
        foreach (Collider collider in _colliderArray)
        {
            if (collider.TryGetComponent(out ObjInteractable objInteractable))
            {
                return objInteractable;
            }
        }
        return null;
    }
}
