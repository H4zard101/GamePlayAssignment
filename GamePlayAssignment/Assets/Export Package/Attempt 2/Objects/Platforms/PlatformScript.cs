using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Attempt_2
{
    public class PlatformScript : MonoBehaviour
    {
        

        public float speed;
        public new Rigidbody rigidbody;
        public bool random;
        float originalY;
        public float floatStrength = 1;  
 
        void Start()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
            this.originalY = this.transform.position.y;
         
            if (random) {
                rigidbody.velocity = Random.value * transform.right * speed;
            }else
            {
                rigidbody.velocity = transform.right * speed;
            }
        }
        
        /*private Rigidbody rb;
         private void Start()
         {
             rb = GetComponent<Rigidbody>();
         }*/
 
        void Update()
        {
            transform.position = new Vector3(originalY + ((float)System.Math.Sin(Time.time) * floatStrength),
                transform.position.y,
                transform.position.z);
        }
        
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
        
        /*void FixedUpdate() {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
        }*/
    }
}
