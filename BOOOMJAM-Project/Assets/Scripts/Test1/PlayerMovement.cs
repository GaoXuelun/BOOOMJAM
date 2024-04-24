using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Setting")]
    [SerializeField] private float _forwardSpeed = 5.0f;
    [SerializeField] private float _upDownSpeed = 10.0f;
    [SerializeField] private float _distance = 3.0f;
    [SerializeField] private int _direction = 1;    // 0 - UP; 1 - MID; 2 - DOWN

    private CharacterController _characterController;
    private CapsuleCollider _capsuleCollider;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void SetMoveDirection(bool isUp)
    {
        _direction += isUp ? 1 : -1;
        _direction = Mathf.Clamp(_direction, 0, 2);
    }

    private void MoveTo()
    {
        // forward
        Vector3 targetPosition = transform.position.x * Vector3.zero;

        // up down
        if (_direction == 0) targetPosition += Vector3.back * _distance;
        else if (_direction == 2) targetPosition += Vector3.forward * _distance;

        // calculate movement
        Vector3 movement = Vector3.zero;
        movement.x = _forwardSpeed;
        movement.z = (targetPosition - transform.position).normalized.z *_upDownSpeed;

        // move player
        _characterController.Move(movement * Time.deltaTime);
    }

    private void Update()
    {
        // get direction
        if (Input.GetKeyDown(KeyCode.W)) SetMoveDirection(true);
        if (Input.GetKeyDown(KeyCode.S)) SetMoveDirection(false);

        MoveTo();
    }
}
