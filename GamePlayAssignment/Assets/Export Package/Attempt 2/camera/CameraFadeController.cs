using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFadeController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
