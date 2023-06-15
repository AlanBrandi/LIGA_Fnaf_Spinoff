using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameobject : MonoBehaviour
{
    [SerializeField] private GameObject oldGameObject;
    [SerializeField] private GameObject newGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oldGameObject.SetActive(false);
            newGameObject.SetActive(true);
        }
    }
}
