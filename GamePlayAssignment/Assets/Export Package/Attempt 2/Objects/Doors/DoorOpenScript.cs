using System;
using System.Collections;
using System.Collections.Generic;
using Attempt_2.Objects.Doors;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    // Start is called before the first frame update
    

    public enum DoorType
    {
        Vertical,
        Horizontal,
        /*DoubleDoor*/
    }
    
    [Header("Type of Door")]
    public DoorType door;
    [Tooltip("The default directions will be UP and RIGHT")]
    public bool invertDirection;
    [Tooltip("I wasn't able to automate whether the door has been rotated, but change the rotation to exactly 90 degrees and it'll work")]
    public bool rotated90Degrees;
    
    
    [Header("Number of Switches Needed")]
    public GameObject[] switches;

    [Header("Switch Timer")]
    [Tooltip("This float is the number of seconds until the door opens.")]
    public bool timer;
    [Range(0,20)]
    public float switchTimer;

    private float switchTimerStart;
    
    
    [Space(10)][Range(0,10)]
    public float moveSpeed;

    [Header("Debug")] 
    public int buttonsPressed;
    
    private Vector3 originalVector3;
    
    public float width;
    public float height;
    public float depth;
    private void Start()
    {
        originalVector3 = transform.localPosition;

        if (!rotated90Degrees)
        {
            width  = GetComponent<Collider>().bounds.size.x;
        }
        else
        {
            width  = GetComponent<Collider>().bounds.size.z;
        }
        
        height = GetComponent<Collider>().bounds.size.y;
        
        if (invertDirection)
        {
            width  *= -1;
            height *= -1; 
        }
    }

    private void Update()
    {
        
        buttonsPressed = 0;
        
        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<SwitchScript>().pressed)
            {
                buttonsPressed++;
            }
        }

        if (buttonsPressed == switches.Length)
        {
            if (timer && switchTimerStart < switchTimer)
            {
                switchTimerStart += Time.deltaTime;
            }
            else
            {
                switch (door)
                {
                    case DoorType.Vertical:
                        MoveVertical();
                        break;
                    case DoorType.Horizontal:
                        MoveHorizontal();
                        break;
                    /*case DoorType.DoubleDoor:
                                break;*/
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
        }
    }

    private void MoveVertical()
    {
        //Debug.Log("Vertical");
        if (transform.localPosition.y < originalVector3.y + height && !invertDirection)
        {
            transform.localPosition += Vector3.up * (moveSpeed * Time.deltaTime);
        }
        else if (transform.localPosition.y > originalVector3.y + height && invertDirection)
        {
            transform.localPosition -= Vector3.up * (moveSpeed * Time.deltaTime);
        }
        
    }
    
    private void MoveHorizontal()
    {
        if (!rotated90Degrees)
        {
            if (transform.localPosition.x < originalVector3.x + width && !invertDirection)
            {
                transform.localPosition += Vector3.right * (moveSpeed * Time.deltaTime);
            }
            else if (transform.localPosition.x > originalVector3.x + width && invertDirection)
            {
                transform.localPosition -= Vector3.right * (moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.localPosition.z < originalVector3.z + width && !invertDirection)
            {
                transform.localPosition += Vector3.forward * (moveSpeed * Time.deltaTime);
            }
            else if (transform.localPosition.z > originalVector3.z + width && invertDirection)
            {
                transform.localPosition -= Vector3.forward * (moveSpeed * Time.deltaTime);
            }
        }
        
    }
}
