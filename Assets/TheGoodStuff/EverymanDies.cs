using UnityEngine;
using System.Collections;

public class EverymanDies : MonoBehaviour
{

    private Animation WalkingAcrossStreet;
    private Animation GetHit;
    private ObstacleSpawner Os;
    // Use this for initialization
    void Start()
    {

        GetHit = GetComponent<Animation>();
        WalkingAcrossStreet = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    /*Make Trigger on Everyman long so car collider hits and
     * allows for animation to play*/


    private void OnTriggerEnter(Collider other)
    {
        GetHit.Play("GettingHitt");
        if (Os.goLog == false)
        {
            WalkingAcrossStreet.Play("WalkingAcrossRoad");
        }
    }



}