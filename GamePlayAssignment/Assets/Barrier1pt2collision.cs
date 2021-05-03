using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier1pt2collision : MonoBehaviour
{
    public GameObject barrier;
    public GameObject player;
    public GameObject respawnPoint;

    public bool respawn;

    // Start is called before the first frame update
    void Start()
    {
        respawn = false;
        barrier.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            player.transform.position = respawnPoint.transform.position;
            barrier.SetActive(false);
            respawn = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            respawn = true;
        }
    }
}
