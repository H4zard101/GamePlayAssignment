using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPlatformForward : MonoBehaviour
{
    public float speed = 30.0f;
    public float speed2 = 30.0f;
    private bool exitTrigger = false;

    public GameObject platform;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            platform.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
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
            if (platform.transform.rotation.z > 0)
            {
                platform.transform.Rotate(Vector3.back * speed2 * Time.deltaTime);

            }
            if (platform.transform.rotation.z < 0)
            {
                exitTrigger = false;

            }
        }
    }
}
