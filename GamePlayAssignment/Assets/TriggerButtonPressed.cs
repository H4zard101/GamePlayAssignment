using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButtonPressed : MonoBehaviour
{
    public GameObject Text;
    public Animator anim;
    public Animator anim2;
    public Animator panningCamera;

    public Camera mainCam;
    public Camera panCam;

    public static bool buttonPressedLeft = false;
    public bool doorOpening;
    public bool doorOpen;

    void Start()
    {
        doorOpening = false;
        doorOpen = false;
        mainCam.enabled = true;
        panCam.enabled = false;
    }

    void Update()
    {
        if (doorOpening)
        {
            panCam.enabled = true;
            mainCam.enabled = false;
        }
        if (doorOpen)
        {
            panCam.enabled = false;
            mainCam.enabled = true;
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
        panningCamera.SetBool("Play", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("trigger", true);
        anim2.SetBool("triggered", true);
        buttonPressedLeft = true;
        yield return new WaitForSeconds(3);
        doorOpening = false;
        doorOpen = true;
    }


}
