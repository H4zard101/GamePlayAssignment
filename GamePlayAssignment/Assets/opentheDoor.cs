using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opentheDoor : MonoBehaviour
{
    public static bool PlayerInDoor = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player Entered");
            PlayerInDoor = true;
        }
    }
}
