using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToRotation : MonoBehaviour
{
   [SerializeField] private Transform transform1;
   [SerializeField] private Transform transform2;

   private void Update()
   {
      transform1.rotation = transform2.rotation;
   }
}
