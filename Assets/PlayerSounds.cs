using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] clips = new AudioClip[2];
    Animator animator;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void Step(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.4)
        {

            int chance = Random.Range(0, 250);
            float pitch = Random.Range(0.8f, 1.2f);
            if (chance != 0)
            {
                audioSource.clip = clips[0];
            }
            else
            {
                audioSource.clip = clips[1];
            }
            audioSource.pitch = pitch;
            audioSource.Play();
        }
    }
}
