using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableByEvent : MonoBehaviour
{
   [SerializeField] private GameObject animatronic;
   [SerializeField] private SwitchManager switchManager;
   
   [Range(1,4)]
   [SerializeField] private int switchToChange;
   [SerializeField] private bool IsActive;
   private void Awake()
   {
      switchManager.onSwitchersOnChanged.AddListener(DisableAnimatronic);
      IsActive = true;
   }
   private void DisableAnimatronic(int switcher)
   {
      if (switcher == switchToChange)
      {
         animatronic.SetActive(false);
         IsActive = false;
      }
   }

   public void ActivateAnimatronic()
   {
      animatronic.SetActive(true);
   }

   public bool IsAnimatronicAtivated()
   {
      return IsActive;
   }
}
