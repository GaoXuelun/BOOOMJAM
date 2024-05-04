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
    }

    private void OnEnable()
    {
        playerInput = new PlayerInputControls();
        playerInput.Gameplay.Confirm.started += OnConfirm;
    }

    private void Update()
    {
        signSprite.GetComponent<SpriteRenderer>().enabled = pressable;
        //signSprite.SetActive(pressable);
    }

    private void OnConfirm(InputAction.CallbackContext obj)
    {
        if (pressable)  targetItem.TriggerAction(); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            pressable = true;
            targetItem = other.GetComponent<InteractableInterface>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))   pressable = false;
    }
}
