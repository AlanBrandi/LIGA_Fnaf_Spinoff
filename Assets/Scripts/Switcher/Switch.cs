using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
   //VERSÃO 0.1
   //FALTA ORGANIZAR ETC.
   public bool counted = false;
   
   private Animator _animator;
   private bool _isActive = false;

   [Header("AudioFX")]
   [SerializeField] private AudioSource lever;
   [SerializeField]private AudioSource switchOn;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   public void ActivateSwitch()
   {
      if(!_isActive)
      {
         _animator.SetBool("Active", true);
         _isActive = true;
         lever.Play();
      }
   }
   public void PlayHumSound()
   {
      if (_isActive)
      {
         switchOn.Play();   
      }
   }

   public void StopHumSound()
   {
      if (_isActive)
      {
         switchOn.Stop();   
      }
   }
   public bool IsActive()
   {
      return _isActive;
   }
}
