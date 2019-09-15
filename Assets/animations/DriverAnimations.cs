using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverAnimations : MonoBehaviour
{

    private Animator animController;

    private void Start()
    {
        animController = GetComponent<Animator>();
    }

    public void SteerLeft()
    {
        animController.SetFloat("SteeringPosition", -1);

    }

    public void SteerCentre()
    {
        animController.SetFloat("SteeringPosition", 0);

    }

    public void SteerRight()
    {
        animController.SetFloat("SteeringPosition", 1);
    }
}
