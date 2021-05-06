using System;
using System.Collections;
using System.Collections.Generic;
using Attempt_2.Player;
using UnityEngine;

public class checkPointScript : MonoBehaviour
{
    private PlayerMovement2 playerMovement2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement2>().respawnPoint = gameObject;
            other.GetComponent<PlayerMovement2>().playerHealth = 100;
        }
    }
}
