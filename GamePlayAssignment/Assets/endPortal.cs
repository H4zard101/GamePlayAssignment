using Attempt_2;
using System.Collections;
using System.Collections.Generic;
using Attempt_2.Player;
using Export_Package.Attempt_2;
using UnityEngine.SceneManagement;
using UnityEngine;
public class endPortal : MonoBehaviour
{
    // Start is called before the first frame update
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jumped through");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            //lowGravity = true;
            //StartCoroutine(Teleport());
        }
    }
}
