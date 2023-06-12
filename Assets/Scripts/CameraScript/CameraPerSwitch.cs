using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerSwitch : MonoBehaviour
{
    [SerializeField] private SwitchManager switchManager;
    [SerializeField] private GameObject oldCamera;
    [SerializeField] private GameObject newCamera;
    private void Awake()
    {
        switchManager.onSwitchersOnChanged.AddListener(ChangeCamera);
    }

    private void ChangeCamera(int switchersOn)
    {
        if (switchersOn == 4)
        {
            oldCamera.SetActive(false);
            newCamera.SetActive(true);
        }
    }
}
