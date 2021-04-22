using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPlatformLeft : MonoBehaviour
{

    public float speed = 50.0f;
    public float speed2 = 30.0f;
    private bool exitTrigger = false;
    public GameObject platform;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            platform.transform.Rotate(Vector3.left * speed * Time.deltaTime);

        }



    }

    private void OnTriggerExit(Collider other)
    {
        exitTrigger = true;

    }

    public void Update()
    {
        if (exitTrigger)
        {
            if (platform.transform.rotation.x < 0)
            {
                platform.transform.Rotate(Vector3.right * speed2 * Time.deltaTime);

            }
            if (platform.transform.rotation.x >= 0)
            {
                exitTrigger = false;

            }
        }
    }
}
