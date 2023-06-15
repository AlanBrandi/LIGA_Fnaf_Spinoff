using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimatronic : MonoBehaviour
{
   [SerializeField] private GameObject animatronic;

   private void OnTriggerEnter(Collider other)
   {
      if(other.CompareTag("Player"))
      {
         animatronic.SetActive(false);
      }
   }
}
