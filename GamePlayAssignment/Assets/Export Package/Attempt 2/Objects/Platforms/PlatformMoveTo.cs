using System;
using UnityEngine;

namespace Attempt_2.Objects.Platforms
{
    public class PlatformMoveTo : MonoBehaviour
    {
        public Vector3 originalPosition;
        public Vector3 targetPosition;

        public bool automatic;
        public bool Slerp;
        public bool tripComplete;
        private bool playerOnBoard;
        
        [Range(0,15)]
        public float movementSpeed;
        // Start is called before the first frame update
        void Start()
        {
            originalPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if ((automatic || playerOnBoard) && !tripComplete)
            {
                if (Slerp)
                {
                    transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * movementSpeed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
                }
            }

            if (Math.Abs(transform.position.x - targetPosition.x) < .025F || Math.Abs(transform.position.y - targetPosition.y) < .025F ||
                Math.Abs(transform.position.z - targetPosition.z) < .025F)
            {
                tripComplete = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!automatic)
            {
                playerOnBoard = true;
            }
        }
        
    }
}
