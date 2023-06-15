using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject triggerToDisable;
    [SerializeField] private GameObject triggerToDisable2;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            triggerToDisable.SetActive(true);
            triggerToDisable2.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
