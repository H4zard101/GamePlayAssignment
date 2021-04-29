using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorsOpen : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(ButtonPressedRight.buttonPressedRight == true && TriggerButtonPressed.buttonPressedLeft == true)
        {
            anim.SetBool("triggered", true);
        }
    }
}
