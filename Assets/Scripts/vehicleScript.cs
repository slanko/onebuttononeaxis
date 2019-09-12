using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vehicleScript : MonoBehaviour
{
    Rigidbody rb, rb2;
    Animator anim;
    GameObject steeringWheel;
    public KeyCode accelerator, brake, turnleft, turnright;
    public float accelAmount, turnForce, carHealthStart, carHealthCurrent, damageThreshold;
    Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("Canvas/healthText").GetComponent<Text>();
        carHealthCurrent = carHealthStart;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb2 = GameObject.Find(transform.name + "/SteeringCube").GetComponent<Rigidbody>();
        steeringWheel = GameObject.Find(transform.name + "/SteeringWheel");
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "car health: " + carHealthCurrent.ToString();
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
            steeringWheel.transform.Rotate(0, -2, 0);
        }
        if (Input.GetKey(turnright))
        {
            steeringWheel.transform.Rotate(0, 2, 0);
            rb2.AddForce(transform.right * turnForce, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.relativeVelocity.magnitude > damageThreshold)
        {
            if(other.gameObject.tag == "Obstacle")
            {
                carHealthCurrent = carHealthCurrent - other.relativeVelocity.magnitude;
                print("crash magnitude: " + other.relativeVelocity.magnitude);
            }
        }
    }
}
