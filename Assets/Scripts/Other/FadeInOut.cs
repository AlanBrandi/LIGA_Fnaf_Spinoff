using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
   private Animator _animator;

   private void Awake()
   {
      _animator = GameObject.Find("Canvas").GetComponent<Animator>();
   }

   public void FadeIn()
   {
      _animator.SetTrigger("FadeIn");
   }

   public void FadeOut()
   {
      _animator.SetTrigger("FadeOut");
   }
}
