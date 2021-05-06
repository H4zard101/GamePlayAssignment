using UnityEngine;

namespace Attempt_2.camera
{
    public class CameraFollow2 : MonoBehaviour 
    {

        public Transform target;
        public float smoothSpeed = 0.125f;
        public Vector3 offset;
        private Vector3 Velocity = Vector3.zero;
    
        void Update()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref Velocity, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }
}
