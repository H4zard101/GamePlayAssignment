using Attempt_2;
using System.Collections;
using System.Collections.Generic;
using Attempt_2.Player;
using Export_Package.Attempt_2;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StepThroughPortal : MonoBehaviour
{
    private PlayerMovement2 stats;
    public GameObject player;
    public GameObject portal2;
    public bool lowGravity;

    public int sceneIndex;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
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
            Debug.Log("jumped through");
            sceneIndex += 1;
            
            if (sceneIndex > 3)
            {
                sceneIndex = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
            }
            
            

            
            //lowGravity = true;
            //StartCoroutine(Teleport());
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
