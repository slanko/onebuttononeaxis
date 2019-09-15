﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerscript : MonoBehaviour
{
    Rigidbody rb;
    public float health = 20;
    public GameObject bloodSplatter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 12.5f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {
            //Instantiate(bloodSplatter, transform.position, new Quaternion(90,0,0,0));
            Destroy(gameObject);
        }
    }
}
