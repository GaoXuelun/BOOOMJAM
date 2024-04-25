using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject _containerGameObj;
    [SerializeField] private PlayerInteract _playerInteract;

    private void Update()
    {
        if (_playerInteract.GetInteractableObj() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        _containerGameObj.SetActive(true);
    }
    private void Hide()
    {
        _containerGameObj.SetActive(false);
    }
}
