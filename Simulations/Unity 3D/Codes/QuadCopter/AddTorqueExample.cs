using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorqueExample : MonoBehaviour{


    public float torquex;
    public float torquey;
    public float torquez;
    public Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
       
        rb.AddTorque(transform.right * torquex);
        rb.AddTorque(transform.up * torquey);
        rb.AddTorque(transform.forward * torquez);
    }
}