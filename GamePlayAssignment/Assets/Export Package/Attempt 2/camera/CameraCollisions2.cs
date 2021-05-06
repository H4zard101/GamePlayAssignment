using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Attempt_2.camera
{
    public class CameraCollisions2 : MonoBehaviour
    {

        public float minDistance = 1f;
        public float maxDistance = 4f;
        public float smooth = 10f;
        public float currentDistance;

        public LayerMask ignoreThisLayerMask;

        public bool notInSpline = true;
        public Vector3 dollyDir;
        public Vector3 originalPosition;

        // Start is called before the first frame update
        void OnEnable()
        {
            originalPosition = transform.position;
            
            var localPosition = transform.localPosition;
            dollyDir = localPosition.normalized;
            currentDistance = localPosition.magnitude;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 desiredCamPos = transform.parent.TransformPoint((dollyDir * maxDistance));
            RaycastHit hit;
            if (Physics.Linecast(transform.parent.position, desiredCamPos, out hit, ~ignoreThisLayerMask))
            { currentDistance = Mathf.Clamp((hit.distance * 0.87f), minDistance, maxDistance);
            }
            else
            {
                currentDistance = maxDistance;
            }

            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * currentDistance, Time.deltaTime * smooth);
        }
    }
}