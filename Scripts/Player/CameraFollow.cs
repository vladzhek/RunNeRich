using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0, 5, -10);
        public float smoothSpeed = 0.125f;

        void Update()
        {
            var desiredPosition = target.position + target.TransformDirection(offset);
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            transform.position = smoothedPosition;
            transform.LookAt(target.position + target.forward);
        }
    }
}