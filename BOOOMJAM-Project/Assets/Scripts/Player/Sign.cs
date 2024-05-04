using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject signSprite;

    private Animator anim;
    private bool pressable;

    private void Awake()
    {
        anim = signSprite.GetComponent<Animator>();
    }

    private void Update()
    {
        signSprite.SetActive(pressable);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))   
        {
            pressable = true;
        }
    }
}
