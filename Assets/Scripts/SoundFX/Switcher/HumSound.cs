using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumSound : MonoBehaviour
{
    [SerializeField] private Switch switcher;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switcher.PlayHumSound();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switcher.StopHumSound();
        }
    }
}
