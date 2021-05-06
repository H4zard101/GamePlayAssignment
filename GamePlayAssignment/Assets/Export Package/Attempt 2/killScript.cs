using System;
using System.Collections;
using System.Collections.Generic;
using Attempt_2.Player;
using Export_Package.Attempt_2;
using UnityEngine;

public class killScript : MonoBehaviour
{
    private PlayerMovement2 playerMovement2;

    public GameObject Player;

    public bool playerHasEntered;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasEntered = true;
            Player.transform.position = other.GetComponent<PlayerMovement2>().respawnPoint.transform.position;
        }
    }
}
