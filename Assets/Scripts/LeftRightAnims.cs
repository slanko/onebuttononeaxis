using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightAnims : MonoBehaviour
{
    private Animation steerLeft;
    private Animation steerRight;
    private Animation acc;
    private vehicleScript Vs;
    // Start is called before the first frame update
    void Start()
    {
        steerLeft = GetComponent<Animation>();
        steerRight = GetComponent<Animation>();
        acc = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.Q))
        {
            acc.Play("driverFootPedal");
        }
        if (Input.GetKey(KeyCode.P))
        {
            acc.Play("driveLeft");
        }
        if (Input.GetKey(KeyCode.Z))
        {
            acc.Play("driveRight");
        }
    }
}
