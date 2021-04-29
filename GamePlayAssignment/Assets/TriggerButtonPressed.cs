using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButtonPressed : MonoBehaviour
{
    public GameObject Text;
    public Animator anim;
    public Animator anim2;

    public Camera mainCam;
    public Camera doorPanCam;

    public static bool buttonPressedLeft = false;
    public bool doorOpening;
    public bool doorOpen;

    void Start()
    {
        doorOpening = false;
        doorOpen = false;
        mainCam.enabled = true;
        doorPanCam.enabled = false;
    }

    void Update()
    {
        if (doorOpening)
        {
            mainCam.enabled = false;
            doorPanCam.enabled = true;
        }
        if (doorOpen)
        {
            mainCam.enabled = true;
            doorPanCam.enabled = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                StartCoroutine(openDoor());
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

    IEnumerator openDoor()
    {
        doorOpening = true;
        yield return new WaitForSeconds(2);
        anim.SetBool("trigger", true);
        anim2.SetBool("triggered", true);
        buttonPressedLeft = true;
        yield return new WaitForSeconds(3);
        doorOpening = false;
        doorOpen = true;
    }


}
