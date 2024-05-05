using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement Setting")]
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody rb;
    //public LayerMask _onGround;

    private Animator anim;
    private SpriteRenderer spriteRender;

    private Vector3 moveInput;
    private bool moveBackward;
    private bool walk;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();        
    }

    private void Update()
    {
        Walk();
        Flip();
        AnimControl();
    }

    private void Walk()
    {
        // move
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.z = Input.GetAxis("Vertical");
        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;
    }

    private void Flip()
    {
        // move left or right
        if (!spriteRender.flipX && moveInput.x < 0)
        {
            spriteRender.flipX = true;
        }
        else if (spriteRender.flipX && moveInput.x > 0)
        {
            spriteRender.flipX = false;
        }
    }

    private void AnimControl()
    {
        // walk
        //_anim.SetFloat("moveSpeed", _rigidbody.velocity.magnitude);
        walk = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        anim.SetBool("walk", walk);            

        // if (!_moveBackward && _moveInput.z > 0)
        // {
        //     _moveBackward = true;
        // }
        // else if (_moveBackward && _moveInput.z < 0)
        // {
        //     _moveBackward = false;
        // }
        // _anim.SetBool("moveBackward", _moveBackward);
    }
}
