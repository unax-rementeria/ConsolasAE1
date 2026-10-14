using UnityEngine;
using System.Collections;
using System.Collections.Generic;
    
public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);
    }
}
    

