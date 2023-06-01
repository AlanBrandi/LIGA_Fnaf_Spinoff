using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private SwitchManager switchManager;

    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level3;
    [SerializeField] private GameObject level4;
    private void Awake()
    {
        switchManager.onSwitchersOnChanged.AddListener(turnLightsOn);
    }

    public void turnLightsOn(int switchersOn)
    {
        switch (switchersOn)
        {
            case 0:
                break;
            case 1:
                level1.SetActive(true);
                break;
            case 2:
                level2.SetActive(true);
                break;
            case 3:
                level3.SetActive(true);
                break;
            case 4:
                level4.SetActive(true);
                break;
        }
    }
}
