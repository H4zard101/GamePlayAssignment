using System;
using System.Collections;
using System.Collections.Generic;
using Attempt_2.Player;
using Export_Package.Attempt_2;
using UnityEngine;

public class LowGravityArea : MonoBehaviour
{
    private PlayerMovement2 stats;
    public GameObject player;
    public bool lowGravity;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        stats = player.GetComponent<PlayerMovement2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lowGravity)
        {
            ///Debug.Log("low grav innit");
            stats.gravity = 14;
            //Debug.Log("stats grav: " + stats.gravity);
            stats.jumpHeight = 6f;
            //Debug.Log("long script grab grav: " + player.GetComponent<PlayerMovement2>().gravity);

        }
        else
        {
            //Debug.Log("reg grav innit");
            stats.gravity = 25f;
            stats.jumpHeight = 2f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //print("does not-a work");
        if (other.CompareTag("Player"))
        {
            //print("works");
            lowGravity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("bye a bye");
            lowGravity = false;
        }
    }
}
