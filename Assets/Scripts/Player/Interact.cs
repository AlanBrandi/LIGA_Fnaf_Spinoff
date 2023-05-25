using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
   //VERSÃO 0.1
   //FALTA ORGANIZAR ETC.
   [SerializeField] private float raycastDistance;
   [SerializeField] private LayerMask layerMask;

   private bool _canInteract;
   private PlayerInput _playerInput;
   private RaycastHit chacheHit;

   private void Awake()
   {
      _playerInput = GetComponent<PlayerInput>();
   }

   private void OnEnable()
   {
      _playerInput.actions["Interact"].performed += InteractWith;
   }

   private void OnDisable()
   {
      _playerInput.actions["Interact"].performed -= InteractWith;
   }

   private void Update()
   { 
      Physics.Raycast(transform.position,transform.forward, out RaycastHit hit, raycastDistance, layerMask);
      if (hit.collider != null)
      {
         if (hit.collider.CompareTag("Switch") || hit.collider.CompareTag("Door"))
         {
            _canInteract = true;
            chacheHit = hit;
         } 
      }
   }

   private void InteractWith(InputAction.CallbackContext obj)
   {
      if (_canInteract)
      {
         switch (chacheHit.collider.tag)
         {
            case "Switch":
               chacheHit.collider.GetComponent<Switch>().ActivateSwitch();
               break;
            case "Door":
               //check qual dor é, e ativa.
               break;
         }
      }
   }
}
