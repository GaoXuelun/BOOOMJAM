using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour, InteractableInterface
{
    [Header("Broadcast")]
    public VoidEventSO saveGameEvent;

    [Header("Variables")]
    public bool isDone;
    [SerializeField] private string interactText;

    private void Awake()
    {

    }

    private void OnEnable()
    {

    }

    public void TriggerAction()
    {
        if (!isDone)
        {
            // this.gameObject.tag = "Untagged";
            saveGameEvent.RaiseEvent();
        }
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
