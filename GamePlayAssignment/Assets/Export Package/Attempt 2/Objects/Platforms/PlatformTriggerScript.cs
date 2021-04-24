﻿using UnityEngine;

namespace Attempt_2
{
    public class PlatformTriggerScript : MonoBehaviour
    {
        Vector3 lastPosition, lastMove;
 
        void FixedUpdate()
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
