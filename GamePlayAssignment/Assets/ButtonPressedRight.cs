using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedRight : MonoBehaviour
{
    public GameObject Text;
    public Animator anim;
    public Animator anim2;

    public static bool buttonPressedRight = false;
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                anim.SetBool("trigger", true);
                anim2.SetBool("triggered", true);
                buttonPressedRight = true;
            }
            Text.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            Text.SetActive(false);
        }
    }


}
