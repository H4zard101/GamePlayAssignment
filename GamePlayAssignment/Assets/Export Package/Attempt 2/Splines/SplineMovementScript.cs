using UnityEngine;

namespace Attempt_2.Splines
{
    public class SplineMovementScript : MonoBehaviour
    {
        public SplinePointScript Spline;

        public Transform followObj;

        private Transform thisTransform;
        
        // Start is called before the first frame update
        void Start()
        {
            thisTransform = transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(followObj);
            thisTransform.position = Spline.WhereOnSpline(followObj.position);
            Debug.DrawLine(transform.position, followObj.position, Color.red);
        }
    }
}
