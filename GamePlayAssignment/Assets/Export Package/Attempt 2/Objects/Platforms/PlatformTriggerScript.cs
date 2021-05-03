using UnityEngine;

namespace Attempt_2.Objects.Platforms
{
    public class PlatformTriggerScript : MonoBehaviour
    {
        Vector3 lastPosition, lastMove;
 
        void Update()
        {
            lastMove = transform.position - lastPosition;
            lastPosition = transform.position;
        }
 
        void OnTriggerStay(Collider other)
        {
            if (!other.attachedRigidbody) return;
            other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + lastMove);
        }
    }
}
