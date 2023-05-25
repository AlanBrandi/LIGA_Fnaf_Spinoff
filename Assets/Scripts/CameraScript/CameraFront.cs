using UnityEngine;

namespace CameraScript
{
    public class CameraFront : MonoBehaviour
    {
        //Change for a new front perspective.
        [SerializeField] Transform realFront;

        //Return  new front;
        public Transform GetRealFront()
        {
            return realFront;
        }
    }
}
