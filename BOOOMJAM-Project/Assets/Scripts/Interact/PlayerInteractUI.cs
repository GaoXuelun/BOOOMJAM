using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObj;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;


    private void Update()
    {
        if (playerInteract.GetInteractableObj() != null)
        {
            Show(playerInteract.GetInteractableObj());
        }
        else
        {
            Hide();
        }
    }
    private void Show(Interactable interactable)
    {
        containerGameObj.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();
    }
    private void Hide()
    {
        containerGameObj.SetActive(false);
    }
}
