using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
    public GameObject signSprite;
    private Animator anim;
    private PlayerInputControls playerInput;
    private InteractableInterface targetItem;
    private bool pressable;

    private void Awake()
    {
        anim = signSprite.GetComponent<Animator>();
        playerInput = new PlayerInputControls();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Gameplay.Confirm.started += OnConfirm;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Gameplay.Confirm.started -= OnConfirm;
        pressable = false;
    }

    private void Update()
    {
        signSprite.GetComponent<SpriteRenderer>().enabled = pressable;
        //signSprite.SetActive(pressable);
    }

    private void OnConfirm(InputAction.CallbackContext obj) // Press keyboard to confirm interact
    {
        if (pressable)  targetItem.TriggerAction(); 
    }

    private void OnTriggerStay(Collider other)  // Enter interactable range
    {
        if (other.CompareTag("Interactable"))
        {
            pressable = true;
            targetItem = other.GetComponent<InteractableInterface>();
        }
    }

    private void OnTriggerExit(Collider other)  // Out interactable range
    {
        if (other.CompareTag("Interactable"))   pressable = false;
    }
}
