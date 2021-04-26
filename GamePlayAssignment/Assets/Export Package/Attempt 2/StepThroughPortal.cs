using Attempt_2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThroughPortal : MonoBehaviour
{
    private PlayerMovement2 stats;
    public GameObject player;
    public GameObject portal2;
    public bool lowGravity;

    private void Awake()
    {
        stats = GameObject.Find("Hammer Warrior").GetComponent<PlayerMovement2>();
    }

    // Update is called once per frame
    void Update()
    {
        lowGravityMode();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lowGravity = true;
            StartCoroutine(Teleport());
        }
    }

    public void lowGravityMode()
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

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0);
        player.transform.position = portal2.transform.position;
        portal2.SetActive(false);
    }
}
