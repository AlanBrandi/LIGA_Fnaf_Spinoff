using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementTank : MonoBehaviour
{
    //VERSÃO 0.1
    //FALTA ORGANIZAR ETC.
    [Header("Speed Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotationSpeed;
    
    [Header("InputSystem")]
    [SerializeField] private InputActionReference move, run;

    private float _currentSpeed;
    private float _rotationMove;
    private float _walkMove;
    
    private Rigidbody _rb;
    private Vector2 _input;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (move.action.ReadValue<Vector2>().x > 0.3 || move.action.ReadValue<Vector2>().x < -0.3)
        {
            _input = move.action.ReadValue<Vector2>();
            RotatePlayer(_input);
        }
        if (move.action.ReadValue<Vector2>().y > 0.3 || move.action.ReadValue<Vector2>().y < -0.3)
        {
            _input = move.action.ReadValue<Vector2>();
            PlayerWalk(_input);
        }
    }
    private void RotatePlayer(Vector2 xInput)
    {
        _rotationMove = (xInput.x * rotationSpeed) * Time.deltaTime;
        this.transform.Rotate(0, _rotationMove, 0);
    }

    private void PlayerWalk(Vector2 yInput)
    {
        _currentSpeed = run.action.IsPressed() ? runSpeed : moveSpeed;
        float moveZ = yInput.y * _currentSpeed;
        float maxSpeed = Mathf.Lerp(0, _currentSpeed, 0.8f);
        float currentSpeed = Mathf.MoveTowards(_currentSpeed, maxSpeed, Time.deltaTime);
        Vector3 moveVelocity = transform.forward * moveZ * currentSpeed;
        _rb.velocity = moveVelocity;
    }
}
