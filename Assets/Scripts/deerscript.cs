using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerscript : MonoBehaviour
{

    float health = 20;
    public GameObject bloodSplatter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(bloodSplatter, transform.position, transform.rotation);
        }
    }
}
