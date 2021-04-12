using System.Collections;
using UnityEngine;

namespace Attempt_2
{
    public class CollisionManager : MonoBehaviour
    {
        //public GameObject player;
        public GameObject sprintPickupEffect;
        public GameObject doubleJumpPickupEffect;
        public GameObject hammerPickupEffect;
        //private MeshRenderer meshRenderer;
        //private SphereCollider sphereCollider;
        
        private bool sprintSpent;
        private bool doubleJumpSpent;
        private bool hammerSpent;
        
        private PlayerMovement2 stats;
        // Start is called before the first frame update
        void Awake()
        {
            stats = gameObject.GetComponent<PlayerMovement2>();
        }

        private void OnTriggerEnter(Collider objectCollidedWith)
        {
            if (objectCollidedWith.CompareTag("PowerupSprint") || 
                objectCollidedWith.CompareTag("PowerupDJ") ||
                objectCollidedWith.CompareTag("Hammer"))
            {
                
                StartCoroutine( Pickup(objectCollidedWith));
                //PlayerMovement2 stats = collider.GetComponent<PlayerMovement2>();
                //stats.maxMovementSpeed *= 2;
            }
        }

        IEnumerator Pickup(Collider objectCollidedWith)
        {
            print("picked up innit");
            if (objectCollidedWith.CompareTag("PowerupSprint"))
            {
                
                if (!sprintSpent)
                {
                    var objectTransform = objectCollidedWith.transform;
                    Instantiate(sprintPickupEffect, objectTransform.position, objectTransform.rotation);
                    
                    Debug.Log("Picked up Sprint");
                    
                    stats.maxMovementSpeed *= 2;
                    sprintSpent = true;
                    
                    Destroy(GameObject.FindWithTag("PowerupSprint"));
                    //objectCollidedWith.GetComponent<MeshRenderer>().enabled = false;
                    //objectCollidedWith.GetComponent<Collider>().enabled = false;
                    
                    yield return new WaitForSeconds(5f);
                    stats.maxMovementSpeed /= 2;
                }
            }

            else if (objectCollidedWith.CompareTag("PowerupDJ"))
            {
                if (!doubleJumpSpent)
                {
                    var objectTransform = objectCollidedWith.transform;
                    Instantiate(doubleJumpPickupEffect, objectTransform.position, objectTransform.rotation);
                    
                    Debug.Log("Picked up Double Jump");
                    
                    doubleJumpSpent = true;
                    
                    Destroy(GameObject.FindWithTag("PowerupDJ"));
                    //objectCollidedWith.GetComponent<MeshRenderer>().enabled = false;
                    //objectCollidedWith.GetComponent<Collider>().enabled = false;
                    
                    stats.maxJumpCount++;
                }
                
            }

            else if (objectCollidedWith.CompareTag("Hammer"))
            {
                if (!hammerSpent)
                {
                    var objectTransform = objectCollidedWith.transform;
                    Instantiate(hammerPickupEffect, objectTransform.position, objectTransform.rotation);
                    
                    Debug.Log("Picked up Hammer");

                    Destroy(GameObject.FindWithTag("Hammer"));
                    //objectCollidedWith.GetComponent<MeshRenderer>().enabled = false;
                    //objectCollidedWith.GetComponent<Collider>().enabled = false;
                    
                    stats.hasHammer = true;
                }
            }
        }
    }
}
