using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

  
    public float throttle;
    void Start()
    {
       
    }
    void FixedUpdate()
    {
        //Change throttle to move up or down
        if (Input.GetKey(KeyCode.UpArrow))
        {
            throttle += 5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            throttle -= 5f;
        }

        throttle = Mathf.Clamp(throttle, 0f, 200f);

       
        transform.Rotate(Vector3.up, throttle);
       
    }
}