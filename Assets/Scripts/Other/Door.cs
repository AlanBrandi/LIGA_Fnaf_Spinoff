using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    //VERSÃO 0.1
    //FALTA ORGANIZAR ETC.
    [SerializeField] private GameObject openingDoor;
    [SerializeField] private GameObject[] newPosition;
    [SerializeField] private GameObject player;

    private bool _opened;
    public void OpenDoor()
    {
        if (!_opened)
        {
            openingDoor.SetActive(true);
            _opened = true;
            Invoke(nameof(ChangePlayerPosition), 3.68f); 
        }
    }

    private void ChangePlayerPosition()
    {
        float maxDistance = 0f;
        Transform farthestPosition = null;
        foreach (GameObject position in newPosition)
        {
            float distance = Vector3.Distance(player.transform.position, position.transform.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestPosition = position.transform;
            }
        }

        if (farthestPosition != null)
        {
            player.transform.position = farthestPosition.position;
            _opened = false;
        }
    }
}
