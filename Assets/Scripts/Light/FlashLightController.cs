using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLightController : MonoBehaviour
{
   [Header("Light/Material")]
   [SerializeField] private Material flashMaterial;
   [SerializeField] private Light light;
   
   [Header("SoundFX")]
   [SerializeField] private AudioClip[] LightOnOff;
   private AudioSource audioSource;
   
   private PlayerInput _playerInput;
   private bool isOn = true;
   private void Awake()
   {
      _playerInput = GetComponent<PlayerInput>();
      _playerInput.actions["Flashlight"].performed += ToggleFlashlight;
      audioSource = GetComponent<AudioSource>();
   }

   private void ToggleFlashlight(InputAction.CallbackContext callbackContext)
   {
      if (isOn)
      {
         flashMaterial.DisableKeyword("_EMISSION");
         light.enabled = false;
         isOn = false;
         audioSource.clip = LightOnOff[0];
         audioSource.Play();
      }
      else
      {
         light.enabled = true;
         flashMaterial.EnableKeyword("_EMISSION");
         isOn = true;
         audioSource.clip = LightOnOff[1];
         audioSource.Play();
      }
   }
}
