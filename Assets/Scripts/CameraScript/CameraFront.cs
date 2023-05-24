using UnityEngine;

namespace CameraScript
{
    public class CameraFront : MonoBehaviour
    {
        [SerializeField] Transform realFront;

        public Transform GetRealFront()
        {
            return realFront;
        }
    }
}
