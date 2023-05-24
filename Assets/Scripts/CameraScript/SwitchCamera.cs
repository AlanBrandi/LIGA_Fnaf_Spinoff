using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject newCamera;
    
    private GameObject currentCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentCamera = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
            if (currentCamera != newCamera)
            {
                SwitchCameras();
                other.GetComponent<PlayerMovement>().GetNewCameraReference();
            }
        }
    }
    private void SwitchCameras()
    {
        currentCamera = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
        currentCamera.SetActive(false);
        newCamera.SetActive(true);
        currentCamera = newCamera;
    }
}
