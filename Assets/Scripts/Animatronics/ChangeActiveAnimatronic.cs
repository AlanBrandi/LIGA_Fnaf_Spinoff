using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveAnimatronic : MonoBehaviour
{
    [SerializeField] private DisableByEvent disableByEvent;
    [SerializeField] private GameObject newAnimatronic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!disableByEvent.IsAnimatronicAtivated())
            {
                newAnimatronic.SetActive(true);
            }
        }
    }
}
