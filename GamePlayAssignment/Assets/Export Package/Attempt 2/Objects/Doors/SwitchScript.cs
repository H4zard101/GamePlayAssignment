using System;
using UnityEngine;

namespace Attempt_2.Objects.Doors
{
    public class SwitchScript : MonoBehaviour
    {
        public enum ButtonType
        {
            SimplePushButton,
            SimpleLever,
            Puzzle
        }
        [Header("Type of Button")]
        public ButtonType button;
        
        public bool pressed;
        [Space(10)][Range(0,10)]
        public float pressSpeed;
        
        private Vector3 originalVector3;
    
        private float width;
        private float height;
        private float depth;
        
        private void Start()
        {
            originalVector3 = transform.localPosition;
        
            width  = GetComponent<Collider>().bounds.size.x;
            height = GetComponent<Collider>().bounds.size.y;
            
        }
        
        private void Update()
        {
            switch (button)
            {
                case ButtonType.SimplePushButton: 
                    PushButton(); 
                    break;
                case ButtonType.SimpleLever: 
                    PushLever(); 
                    break;
                case ButtonType.Puzzle:
                    break;
                default: 
                    throw new ArgumentOutOfRangeException();
            }
        }

        void PushLever()
        {
            if (pressed)
            {
                transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 33);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -33);
            }
        }

        void PushButton()
        {
           // if (pressed)
            //{
             //   transform.localPosition += Vector3.forward * (pressSpeed * Time.deltaTime);
            //}
            //else
            //{
              //  transform.localPosition = originalVector3;
            //}
        }
    }
}
