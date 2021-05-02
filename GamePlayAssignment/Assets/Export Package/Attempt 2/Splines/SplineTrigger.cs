using UnityEngine;

namespace Attempt_2.Splines
{
    public class SplineTrigger : MonoBehaviour
    {

        public GameObject SplineCamera;
        public GameObject FollowCamera;

        public bool playerInSplineArea;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SplineCamera.SetActive(true);
                FollowCamera.SetActive(false);
                playerInSplineArea = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SplineCamera.SetActive(false);
                FollowCamera.SetActive(true);
                playerInSplineArea = false;
            }
        }
    }
}
