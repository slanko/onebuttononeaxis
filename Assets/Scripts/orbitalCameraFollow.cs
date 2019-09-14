using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitalCameraFollow : MonoBehaviour
{
    GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.transform.position;
    }
}
