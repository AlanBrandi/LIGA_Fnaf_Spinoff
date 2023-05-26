using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
   //VERSÃO 0.1
   //FALTA ORGANIZAR ETC.
   public bool counted = false;
   
   private Animator _animator;
   private bool _isActive = false; 

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
         //playSound
      }
   }

   public bool IsActive()
   {
      return _isActive;
   }
}
