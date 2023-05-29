using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExample : MonoBehaviour
{
   [SerializeField] private SwitchManager switchManager;
   private void Awake()
   {
      switchManager.onSwitchersOnChanged.AddListener(Test);
   }

   private void Test(int switcher)
   {
      Debug.Log("Test event check: " + switcher);
   }
}
