using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControls inputControl;
    private Rigidbody rigidbody;
    private SpriteRenderer spriteRender;
    private PhysicsCheck physicsCheck;

    public bool canMove = true; //修改添加一个变量用于控制人物是否可以移动
    public bool canInteract = true; //修改添加一个变量用于控制人物是否可以交互

    [Header("Movement Setting")]
    public Vector2 inputDirection;
    public float moveSpeed = 200.0f;


    private void Awake()
    {
        inputControl = new PlayerInputControls();
        rigidbody = GetComponent<Rigidbody>();
        spriteRender = GetComponent<SpriteRenderer>();
        physicsCheck = GetComponent<PhysicsCheck>(); 
        inputControl.Gameplay.Move.performed += ctx => inputDirection = ctx.ReadValue<Vector2>();//修改
        inputControl.Gameplay.Move.canceled += ctx => inputDirection = Vector2.zero;        
    }
    private void Update()
    {
        //修改如果不能移动或对话框活动，则清空输入方向
        if (canMove)
        {
            inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
        }
        else
        {
            inputDirection = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    private void OnEnable()
    {
        inputControl.Gameplay.Enable();
    }
    private void OnDisable()
    {
        inputControl.Gameplay.Disable();
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
