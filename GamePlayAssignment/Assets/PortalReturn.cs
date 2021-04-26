using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalReturn : MonoBehaviour
{
    private StepThroughPortal stats;
    public GameObject player;
    public GameObject portal2;

    private void Awake()
    {
        stats = GameObject.Find("Portal1").GetComponent<StepThroughPortal>();
    }

    // Start is called before the first frame update
    void Start()
    {
        portal2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Teleport());
            stats.lowGravity = false;
        }
    }

    IEnumerator Teleport()
    {
        portal2.SetActive(true);
        yield return new WaitForSeconds(0);
        player.transform.position = portal2.transform.position;
        portal2.SetActive(false);
    }
}
