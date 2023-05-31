using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    //Reference for the new camera.
    [SerializeField] private GameObject newCamera;
    
    //Get current camera.
    private GameObject currentCamera;
    //Collision with player.
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Get camera reference.
            currentCamera = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
            if (currentCamera != newCamera)
            {
                //Switch for the new camera.
                SwitchCameras();
                other.GetComponent<PlayerMovement>().GetNewCameraReference();
            }
        }
    }
    //Switch camera method.
    private void SwitchCameras()
    {
        currentCamera = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
        currentCamera.SetActive(false);
        newCamera.SetActive(true);
        currentCamera = newCamera;
    }
}
