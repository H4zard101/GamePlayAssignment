using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingScript : MonoBehaviour
{
    void OnCollisionEnter (Collision platform)
    {
        if (platform.collider.CompareTag("Moving Platform"))
        {
            gameObject.transform.parent = platform.transform;
        }
    }
    void OnCollisionExit ()
    {
        gameObject.transform.parent = null;
    }
}
