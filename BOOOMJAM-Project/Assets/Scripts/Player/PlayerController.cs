using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControl inputControl;
    private Rigidbody rigidbody;
    private SpriteRenderer spriteRender;
    private PhysicsCheck physicsCheck;

    [Header("Movement Setting")]
    public Vector2 inputDirection;
    public float moveSpeed = 200.0f;


    private void Awake()
    {
        inputControl = new PlayerInputControl();
        rigidbody = GetComponent<Rigidbody>();
        spriteRender = GetComponent<SpriteRenderer>();
        physicsCheck = GetComponent<PhysicsCheck>(); 
    }
    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }
    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Move()
    {
        rigidbody.velocity = new Vector3(inputDirection.x * moveSpeed * Time.deltaTime, rigidbody.velocity.y, inputDirection.y * moveSpeed * Time.deltaTime);
    }
    private void Flip()
    {
        // move left or right
        if (inputDirection.x < 0) spriteRender.flipX = true;;
        if (inputDirection.x > 0) spriteRender.flipX = false;
    }
}
