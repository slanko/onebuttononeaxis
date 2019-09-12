using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    private bool goLog;

    // Start is called before the first frame update
    void Start()
    {
        obstacle.SetActive(false);
        goLog = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (goLog == false && other.gameObject.tag == "Car")
        {
            obstacle.SetActive(true);
            goLog = true;
        }
    }
}