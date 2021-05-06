using System;
using System.Collections;
using System.Collections.Generic;
using Attempt_2.Player;
using UnityEngine;

public class LowGravityArea : MonoBehaviour
{ 
    
    
    private PlayerMovement2 stats;
    public GameObject player;
    public bool lowGravity;
    // Start is called before the first frame update
    void Awake()
    {
        //player = GameObject.FindWithTag("Player");
        stats = player.GetComponent<PlayerMovement2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lowGravity)
        {
            stats.gravity = 14f;
            stats.jumpHeight = 6f;
        }
        else
        {
            stats.gravity = 25f;
            stats.jumpHeight = 2f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //print("does not-a work");
        if (other.CompareTag("Player"))
        {
            print("works");
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
