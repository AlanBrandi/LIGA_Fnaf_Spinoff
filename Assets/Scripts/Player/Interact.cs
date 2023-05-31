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
   private RaycastHit cacheHit;
   private RaycastHit nullHit;

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
            cacheHit = hit;
         }
         else
         {
            _canInteract = true;
            cacheHit = new RaycastHit();
         }
      }
      else
      {
         _canInteract = true;
         cacheHit = new RaycastHit();
      }
   }

   private void InteractWith(InputAction.CallbackContext obj)
   {
      if (_canInteract)
      {
         switch (cacheHit.collider.tag)
         {
            case "Switch":
               cacheHit.collider.GetComponent<Switch>().ActivateSwitch();
               break;
            case "Door":
               cacheHit.collider.GetComponent<Door>().OpenDoor();
               break;
         }
      }
   }
}
