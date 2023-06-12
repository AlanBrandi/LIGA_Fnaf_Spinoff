using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SwitchManager switchManager;

    private ChangeScene _changeScene;
    private void Awake()
    {
        switchManager.onSwitchersOnChanged.AddListener(WinGame);
        _changeScene = GetComponent<ChangeScene>();
    }

    private void WinGame(int switcher)
    {
        if (switcher == 5)
        {
            _changeScene.ChangeSceneByName("Win");
        }
    }
}
