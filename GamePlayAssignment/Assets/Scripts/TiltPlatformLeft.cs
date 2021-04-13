using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPlatformLeft : MonoBehaviour
{
    public float speed = 5.0F;

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

        Debug.Log("exit tilt");
    }
}
