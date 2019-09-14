using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogLow : MonoBehaviour
{
    public GameObject TheLog;
    public GameObject FakeLog;
    public Rigidbody rbLeft;
    public Rigidbody rbRight;
    public float launchAmount;
    ParticleSystem woodParticle;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            TheLog.SetActive(false);
            FakeLog.SetActive(true);
            rbLeft.AddForce(transform.forward * launchAmount, ForceMode.Impulse);
            rbRight.AddForce(transform.forward * launchAmount, ForceMode.Impulse);
            woodParticle.Play();
        }
    }
}
