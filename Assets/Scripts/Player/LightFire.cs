using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightFire : MonoBehaviour
{
    private Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }
    //Trocar para coroutine.
    private void Update()
    {
        light.intensity = Random.Range(0.50f, 0.58f);
    }
}
