using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door;
    public bool stayOpen;
    public bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        stayOpen = false;
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stayOpen)
        {
            if (door.transform.position.y < 18.98)
            {
                door.transform.Translate(Vector3.up * Time.deltaTime * 5);
            }
            if (door.transform.position.y > 18.98)
            {
                doorOpen = true;
            }
        }
        if (doorOpen)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stayOpen = true;
        }
    }
}
