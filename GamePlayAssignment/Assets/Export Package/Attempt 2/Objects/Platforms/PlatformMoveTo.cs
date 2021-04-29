using UnityEngine;

namespace Attempt_2.Objects.Platforms
{
    public class PlatformMoveTo : MonoBehaviour
    {
        public Vector3 originalPosition;
        public Vector3 targetPosition;

        public bool automatic;
        private bool playerOnBoard;
        
        [Range(0,15)]
        public float movementSpeed;
        // Start is called before the first frame update
        void Start()
        {
            originalPosition = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (automatic)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movementSpeed);
            }
        }
    }
}
