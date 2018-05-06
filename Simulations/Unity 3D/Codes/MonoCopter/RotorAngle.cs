using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorAngle : MonoBehaviour
{



    void Start()
    {

    }

    void FixedUpdate()

    { 
        transform.Rotate(Vector3.up, 50f);

    }
}