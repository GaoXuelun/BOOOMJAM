using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface InteractableInterface
{
    void TriggerAction();
    string GetInteractText();
    Transform GetTransform();
}

