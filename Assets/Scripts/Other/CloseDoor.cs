using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private AudioSource openDoor;
    [SerializeField] private AudioSource closeDoor;
    [SerializeField] private AudioSource walk;
    public void CloseDoorAnimation()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenDoorSound()
    {
        openDoor.pitch = Random.Range(0.8f, 1.2f);
        openDoor.Play();
    }

    public void WalkingIn()
    {
        walk.Play();
    }

    public void CloseDoorSound()
    {
        closeDoor.pitch = Random.Range(0.8f, 1.2f);
        closeDoor.Play();
    }
}
