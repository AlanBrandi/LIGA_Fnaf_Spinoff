using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public void CloseDoorAnimation()
    {
        this.gameObject.SetActive(false);
    }
}
