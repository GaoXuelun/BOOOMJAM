using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement Setting")]
    [SerializeField] private float _moveSpeed = 5.0f;

    private Rigidbody _rigidbody;
    //public LayerMask _onGround;

    private Animator _anim;
    private SpriteRenderer _spriteRender;

    private Vector3 _moveInput;
    private bool _moveBackward;
    private bool _walk;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _spriteRender = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();        
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
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.z = Input.GetAxis("Vertical");
        _moveInput.Normalize();
        _rigidbody.velocity = _moveInput * _moveSpeed;
    }

    private void Flip()
    {
        // move left or right
        if (!_spriteRender.flipX && _moveInput.x < 0)
        {
            _spriteRender.flipX = true;
        }
        else if (_spriteRender.flipX && _moveInput.x > 0)
        {
            _spriteRender.flipX = false;
        }
    }

    private void AnimControl()
    {
        // walk
        //_anim.SetFloat("moveSpeed", _rigidbody.velocity.magnitude);
        _walk = Mathf.Abs(_moveInput.x) > Mathf.Epsilon;
        _anim.SetBool("walk", _walk);            

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
