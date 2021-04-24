using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformingscript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionStay (Collision platform)
        {
            gameObject.transform.parent = platform.transform;
        }
        void OnCollisionExit ()
        {
            gameObject.transform.parent = null;
        }
}
