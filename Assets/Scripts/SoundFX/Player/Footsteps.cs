using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Footsteps : MonoBehaviour
{
   [SerializeField] private AudioClip[] footsteps;
   private AudioSource audioSource;

   private void Awake()
   {
      audioSource = GetComponent<AudioSource>();
   }

   public void PlaySound()
   {
      int randomIndex = Random.Range(0, 100); 

      if (randomIndex < 80)
      {
         audioSource.clip = footsteps[0];
         Play();
      }
      else
      {
         audioSource.clip = footsteps[1];
         Play();
      }
   }

   private void Play()
   {
      audioSource.pitch = Random.Range(0.8f, 1.2f);
      audioSource.Play();
   }

}
