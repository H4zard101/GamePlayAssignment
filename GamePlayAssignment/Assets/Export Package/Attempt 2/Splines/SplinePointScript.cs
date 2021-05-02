using UnityEngine;

namespace Attempt_2.Splines
{
    public class SplinePointScript : MonoBehaviour
    {

        private Vector3[] splinePoint;

        private int splineCount;

        public bool debugDrawSpline = true;
        // Start is called before the first frame update
        void Start()
        {
            splineCount = transform.childCount;
            splinePoint = new Vector3[splineCount];

            for (int i = 0; i < splineCount; i++)
            {
                splinePoint[i] = transform.GetChild(i).position;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (splineCount > 1 && debugDrawSpline)
            {
                for (int i = 1; i < splineCount; i++)
                {
                    Debug.DrawLine(splinePoint[i - 1], splinePoint[i], Color.magenta);
                }
            }
        }

        public Vector3 WhereOnSpline(Vector3 pos)
        {
            var closestSplinePoint = GetClosestSplinePoint(pos);

            if (closestSplinePoint == 0)
            {
                return SplineSegment(splinePoint[0], splinePoint[1], pos);
            }
            else if (closestSplinePoint == splineCount - 1)
            {
                return SplineSegment(splinePoint[splineCount - 1], splinePoint[splineCount - 2], pos);
            }
            else
            {
                Vector3 leftSeg = SplineSegment(splinePoint[closestSplinePoint - 1], splinePoint[closestSplinePoint],
                    pos);
                Vector3 rightSeg = SplineSegment(splinePoint[closestSplinePoint + 1], splinePoint[closestSplinePoint],
                    pos);
                if ((pos - leftSeg).sqrMagnitude <= (pos - rightSeg).sqrMagnitude)
                {
                    return leftSeg;
                }
                else
                {
                    return rightSeg;
                }
            }
        }

        private int GetClosestSplinePoint(Vector3 pos)
        {
            var closestPoint = -1;
            var shortestDistance = 0.0F;

            for (var i = 0; i < splineCount; i++)
            {
                var sqrDistance = (splinePoint[i] - pos).sqrMagnitude;
                if (shortestDistance == 0.0F || sqrDistance < shortestDistance)
                {
                    shortestDistance = sqrDistance;
                    closestPoint = i;
                }
            }

            return closestPoint;
        }

        public Vector3 SplineSegment(Vector3 v1, Vector3 v2, Vector3 pos)
        {
            Vector3 v1ToPos = pos - v1;
            Vector3 seqDirection = (v2 - v1).normalized;

            float distanceFromV1 = Vector3.Dot(seqDirection, v1ToPos);

            if (distanceFromV1 < 0.0F)
            {
                return v1;
            }
            else if (distanceFromV1 * distanceFromV1 > (v2 - v1).sqrMagnitude)
            {
                return v2;
            }
            else
            {
                Vector3 fromV1 = seqDirection * distanceFromV1;
                return v1 + fromV1;
            }
        }
    }
    
}
