using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
   //VERSÃO 0.1
   //FALTA ORGANIZAR ETC.
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
         SetAsActive();
         //playSound
      }
   }

   private void SetAsActive()
   {
      //pegar o generador manager e dar set como ativado.
   }
}
