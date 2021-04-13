using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTheSpeedDoor : MonoBehaviour
{

    public Animator anim;
    public Transform Door;
    public float Speed = 5.0F;
    // Start is called before the first frame update

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Door Move Up");
            anim.SetBool("Open", true);
            anim.SetBool("Close", false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Door Move Down");
        anim.SetBool("Close", false);
        anim.SetBool("Open", false);
        anim.SetBool("StopAnimation", true);
    }
}
