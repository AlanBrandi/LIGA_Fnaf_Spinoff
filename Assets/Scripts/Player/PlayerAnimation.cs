using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
   [SerializeField] private InputActionReference move;
   private Rigidbody _rb;
   private Animator _animator;
   
   private void Awake()
   {
      _animator = GetComponentInChildren<Animator>();
      _rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      _animator.SetFloat("Velocity", _rb.velocity.magnitude);
      _animator.SetFloat("VelocityX", move.action.ReadValue<Vector2>().x);
   }
}
