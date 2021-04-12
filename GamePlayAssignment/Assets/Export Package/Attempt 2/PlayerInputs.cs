using UnityEngine;

namespace Attempt_2
{
    public class PlayerInputs : MonoBehaviour
    {
        private GameObject player;
        private float speed;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (GameObject.FindGameObjectWithTag("Player") == true)
            {
                print("Got Player");
            }
        }

        // Update is called once per frame
        void Update()
        {
            /*Keyboard innit*/
        
            /*if (Input.GetKey(KeyCode.W))
            {
                print("forwards");
            }
            if(Input.GetKey(KeyCode.S))
            {
                print("backwards");
            }
            if(Input.GetKey(KeyCode.A))
            {
                print("leftwards");
            }
            if(Input.GetKey(KeyCode.D))
            {
                print("rightwards");
            }*/
        
            /*Controller*/

            //Left Stick
            
        }
    }
}
