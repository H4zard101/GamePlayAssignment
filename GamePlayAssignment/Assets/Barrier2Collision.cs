using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier2Collision : MonoBehaviour
{
    public GameObject barrier;
    public GameObject player;
    public GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        barrier.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = respawnPoint.transform.position;
            barrier.SetActive(false);
        }
    }
}
