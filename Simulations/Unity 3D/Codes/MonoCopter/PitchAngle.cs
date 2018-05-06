using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchAngle : MonoBehaviour
{

    public float Beta;
    private float Angle = 0f;
  
    void Start()
    {
       
    }
    void FixedUpdate()
    {
        

        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            Beta += 1f;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
        
            Beta -= 1f;
            
        }

        Beta = Mathf.Clamp(Beta, 0f, 90f);

       

        Vector3 Position = transform.position;
        Position.z = 1f;
       
        transform.Rotate(Vector3.forward, Beta-Angle);

        Angle = Beta;
       
       
    }
}