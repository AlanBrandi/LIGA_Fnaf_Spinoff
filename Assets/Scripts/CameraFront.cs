using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFront : MonoBehaviour
{
    [SerializeField] Transform realFront;

    public Transform GetRealFront()
    {
        return realFront;
    }
}
