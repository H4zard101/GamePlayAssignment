using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Attempt_2
{
    public class PlatformScript : MonoBehaviour
    {
        public bool vertical;
        public bool rotated90Degrees;
        
        public float speed;

        float originalX;
        float originalY;
        float originalZ;
        
        public float floatStrength = 1;  
 
        void Start()
        {
            originalX = transform.position.x;
            originalY = transform.position.y;
            originalZ = transform.position.z;
        }
        
        /*private Rigidbody rb;
         private void Start()
         {
             rb = GetComponent<Rigidbody>();
         }*/
        Vector3 lastPosition, lastMove;
        void Update()
        {
            if (vertical)
            {
                transform.position = new Vector3(transform.position.x,
                    originalY + ((float)System.Math.Sin(Time.time) * floatStrength), transform.position.z);
            }
            else
            {
                if (!rotated90Degrees)
                {
                    transform.position = new Vector3(originalX + ((float)System.Math.Sin(Time.time) * floatStrength),
                        transform.position.y,
                        transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x ,
                        transform.position.y, originalZ + ((float)System.Math.Sin(Time.time) * floatStrength));
                }
               
            }

        }
 

        
        /*void FixedUpdate() {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
        }*/
    }
}
