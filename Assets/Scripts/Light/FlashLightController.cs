using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLightController : MonoBehaviour
{
   [SerializeField] private Material flashMaterial;
   [SerializeField] private Light light;
   
   private PlayerInput _playerInput;
   private bool isOn = true;
   private void Awake()
   {
      _playerInput = GetComponent<PlayerInput>();
      _playerInput.actions["Flashlight"].performed += ToggleFlashlight;
   }

   private void ToggleFlashlight(InputAction.CallbackContext callbackContext)
   {
      if (isOn)
      {
         flashMaterial.DisableKeyword("_EMISSION");
         light.enabled = false;
         isOn = false;
      }
      else
      {
         light.enabled = true;
         flashMaterial.EnableKeyword("_EMISSION");
         isOn = true;
      }
   }
}
