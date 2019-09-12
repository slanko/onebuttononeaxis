using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleScript : MonoBehaviour
{
    Rigidbody rb, rb2;
    Animator anim;
    GameObject steeringWheel;
    public KeyCode accelerator, brake, turnleft, turnright;
    public float accelAmount, turnForce, carHealthStart, carHealthCurrent;
    // Start is called before the first frame update
    void Start()
    {
        carHealthCurrent = carHealthStart;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb2 = GameObject.Find(transform.name + "/SteeringCube").GetComponent<Rigidbody>();
        steeringWheel = GameObject.Find(transform.name + "/SteeringWheel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(accelerator))
        {
            anim.SetBool("accelPressed", true);
            rb.AddForce(transform.forward * accelAmount, ForceMode.Acceleration);
        }
        else
        {
            anim.SetBool("accelPressed", false);
        }
        if (Input.GetKey(brake))
        {
            anim.SetBool("brakePressed", true);
            rb.AddForce(transform.forward * (accelAmount * -1), ForceMode.Acceleration);
        }
        else
        {
            anim.SetBool("brakePressed", false);
        }
        if (Input.GetKey(turnleft))
        {
            rb2.AddForce((transform.right * -1) * turnForce, ForceMode.Acceleration);
        }
        if (Input.GetKey(turnright))
        {
            rb2.AddForce(transform.right * turnForce, ForceMode.Acceleration);
        }
    }
}
