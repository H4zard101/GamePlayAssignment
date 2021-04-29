using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTheSpeedDoor : MonoBehaviour
{

    public GameObject door;
    public bool doorOpening;
    public bool doorClosing;
    // Start is called before the first frame update

    private void Start()
    {
        doorOpening = false;
        doorClosing = false;
    }

    private void Update()
    {
        if (doorOpening)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if (door.transform.position.y > 18.98)
        {
            doorOpening = false;
        }
        if (doorClosing)
        {
            door.transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
            if (door.transform.position.y < 12.98)
            {
                doorClosing = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Door Move Up");
            doorOpening = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Door Move Down");
        doorClosing = true;
    }
}
