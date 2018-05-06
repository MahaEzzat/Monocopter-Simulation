using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCopter : MonoBehaviour
{

    public GameObject Rotor;
    public GameObject Wing;

    public float Beta;
    public float moveFactor; //5

    Rigidbody quadcopterRB;

    //Movement factors
    float moveForwardBack;
    float moveLeftRight;
    float yawDir;
    private float deltaW;
    private float deltaU;
    private float t;
    private int k;
    private float t1 = 0f; 
    private float deltaU0 = 0f;
    private float deltaW0 = 0f;
    private float E_AT;
    private float deltaOmega;
    private float Omega=0f;

    void Start()
    {
        quadcopterRB = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        AddControls();

        StatesCal();

        AddMotorForce();
        
    }


    void AddControls()
    {
        k = 0;
        //Change throttle to move up or down
        if (Input.GetKey(KeyCode.UpArrow))
        {
            k = 1;
            Beta += 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            k = -1;
            Beta -= 1f;
        }

        Beta = Mathf.Clamp(Beta, 0f, 90f);
    }


    void AddMotorForce()
    {
        Vector3 propellerUp = quadcopterRB.transform.up;

        Vector3 propellerPos = quadcopterRB.transform.position;

        quadcopterRB.AddTorque(transform.up * Omega);
        quadcopterRB.AddForceAtPosition(Vector3.up *  moveFactor*deltaW, propellerPos); //force in y
        quadcopterRB.AddForceAtPosition(Vector3.right *  moveFactor*deltaU, propellerPos); //force in x
        
    }

    void StatesCal()
    {
        if (k == 0)
        {
            deltaU0 = 0;
            deltaW0 = 0;
            t = Time.realtimeSinceStartup;     
        }
        else
        {
            t = Time.realtimeSinceStartup - t1;
        }
       
            deltaU = (1.7491f * Mathf.Pow(10f, -22f)) - (6.5305f * Mathf.Pow(10f, -19f)) * t + (9.7967f * Mathf.Pow(10f, -16f)) * Mathf.Pow(t, 2f) - (7.5367f * Mathf.Pow(10f, -13f)) * Mathf.Pow(t, 3f) + 3.1407f * Mathf.Pow(10, -10f) * Mathf.Pow(t, 4f) - 6.8537f * Mathf.Pow(10f, -8f) * Mathf.Pow(t, 5f) + 6.8555f * Mathf.Pow(10f, -6f) * Mathf.Pow(t, 6f) + 0.0335f * Mathf.Pow(t, 7f);
            deltaW = (-4.5908f * Mathf.Pow(10f, -21f)) + (1.7273f * Mathf.Pow(10f, -17f)) * t - (2.6170f * Mathf.Pow(10f, -14f)) * Mathf.Pow(t, 2f) + (2.0402f * Mathf.Pow(10f, -11f)) * Mathf.Pow(t, 3f) - 8.6621f * Mathf.Pow(10, -9f) * Mathf.Pow(t, 4f)  + 1.9441f * Mathf.Pow(10, -6f) * Mathf.Pow(t, 5f) - 2.0378f * Mathf.Pow(10f, -4f) * Mathf.Pow(t, 6f) - 0.009f * Mathf.Pow(t, 7f);
            deltaOmega = (-1.0143f * Mathf.Pow(10f, -20f)) + (3.8333f * Mathf.Pow(10f, -17f)) * t - (5.8407f * Mathf.Pow(10f, -14f)) * Mathf.Pow(t, 2f) + (4.5873f * Mathf.Pow(10f, -11f)) * Mathf.Pow(t, 3f) - 1.9676f * Mathf.Pow(10f, -8f) * Mathf.Pow(t, 4f) + 4.4818f * Mathf.Pow(10f, -6f) * Mathf.Pow(t, 5f) - 4.8086f * Mathf.Pow(10f, -4f) * Mathf.Pow(t, 6f) + 0.0175f * Mathf.Pow(t, 7f);
            Omega = Omega + deltaOmega * Time.fixedDeltaTime;
            t1 = t;
        
    }
}
