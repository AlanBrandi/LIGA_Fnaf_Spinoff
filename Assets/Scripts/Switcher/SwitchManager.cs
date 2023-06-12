using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SwitchManager : MonoBehaviour
{
    //VERSÃO 1
    //FALTA COMENTAR.
    [Header("Switcher config")]
    [SerializeField] private float timeToWait = 1f;
    [SerializeField] private List<Transform> spawnLocation;
    [SerializeField] private Transform finalLocation;
    [SerializeField] private GameObject switcherGO;

    private bool LastSwitchAtivated = false;
    
    [HideInInspector]
    public UnityEvent<int> onSwitchersOnChanged;
    
    private List<Switch> _switchers;
    private int _switchersOn = 0;
    
    private void Awake()
    {
        _switchers = new List<Switch>(); 
        int instantiatedSwitchers = 0;
        System.Random random = new System.Random();

        while (spawnLocation.Count > 0 && instantiatedSwitchers < 4)
        {
            int randomIndex = random.Next(0, spawnLocation.Count);
            Transform spawn = spawnLocation[randomIndex];
            spawnLocation.RemoveAt(randomIndex);

            if (!HasSwitchAtPosition(spawn.position))
            {
                GameObject var = Instantiate(switcherGO, spawn.position, spawn.rotation);
                Switch switcher = var.GetComponent<Switch>();
                _switchers.Add(switcher);
                var.tag = "Switch";
                var.layer = 3;
                instantiatedSwitchers++;
            }
            else
            {
                return;
            }
        }
    }


    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            CheckSwitchersActive();
        }
    }
    private bool HasSwitchAtPosition(Vector3 position)
    {
        foreach (Switch switcher in _switchers)
        {
            if (switcher.transform.position == position)
            {
                return true;
            }
        }
        return false;
    }
    private void CheckSwitchersActive()
    {
        foreach (Switch switcher in _switchers)
        {
            if (switcher.IsActive() && !switcher.counted)
            {
                _switchersOn++;
                switcher.counted = true;
            }
        }
        switch (_switchersOn)
        {
            case 0:
                NotifySwitchers();
                break;
            case 1:
                NotifySwitchers();
                break;
            case 2:
                NotifySwitchers();
                break;
            case 3:
                NotifySwitchers();
                break;
            case 4:
                if (!LastSwitchAtivated)
                {
                    GameObject var = Instantiate(switcherGO, finalLocation.position, finalLocation.rotation);
                    _switchers.Add(var.GetComponent<Switch>());
                    LastSwitchAtivated = true;
                    NotifySwitchers(); 
                }
                break;
            case 5:
                NotifySwitchers();
                StopCoroutine(nameof(CheckSwitchersActive));
                break;
        }
    }
    private void NotifySwitchers()
    {
        onSwitchersOnChanged.Invoke(_switchersOn);
    }
}
