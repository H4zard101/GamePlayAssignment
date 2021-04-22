using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPlatformBack : MonoBehaviour
{
    public float speed = 50.0f;
    public float speed2 = 30.0F;
    public Transform origintransform;
    public GameObject platform;


    private void Start()
    {
        platform.transform.Rotate(0, 0, 0);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            platform.transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }



    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit tilt");
        platform.transform.Rotate(Vector3.right * speed2 * Time.deltaTime);
    }
}
