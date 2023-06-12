using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
   [SerializeField] private LayerMask layerMask;

   private bool _canInteract;
   private PlayerInput _playerInput;
   private GameObject cacheHit;
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
      Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2, layerMask);

      foreach (Collider hitCollider in hitColliders)
      {
         if (hitCollider != null)
         {
            if (hitCollider.CompareTag("Switch") || hitCollider.CompareTag("Door"))
            {
               _canInteract = true;
               cacheHit = hitCollider.gameObject;
               Debug.Log("HIT COLLIDER != NULL");
            }
         }
         else
         {
            _canInteract = true;
            cacheHit = new GameObject();
            Debug.Log("HIT NULL");
         }
      }
   }

   private void InteractWith(InputAction.CallbackContext obj)
   {
      if (_canInteract)
      {
         switch (cacheHit.tag)
         {
            case "Switch":
               cacheHit.GetComponent<Switch>().ActivateSwitch();
               break;
            case "Door":
               cacheHit.GetComponent<Door>().OpenDoor();
               break;
         }
      }
   }
}
