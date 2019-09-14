using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : MonoBehaviour
{
    public GameObject ghost;
    public float lerpTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, ghost.transform.rotation, lerpTime);
    }
}
