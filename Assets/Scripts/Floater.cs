using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Floater : MonoBehaviour
{
    // Start is called before the first frame update
    //public Rigidbody rigidbody;
    public float waterlevel = 0.0f;
    public float floatThreshold = 2.0f;
    public float waterDensity = 0.125f;
    public float DownForce = 4.0f;

    float forcefactor;
    Vector3 floatForce;
    void FixedUpdate()
    {
        forcefactor = 1.0f - ((transform.position.y - waterlevel) / floatThreshold);
        if(forcefactor>0.0f)
        {
            floatForce = -Physics.gravity *GetComponent<Rigidbody>().mass* (forcefactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -DownForce* GetComponent<Rigidbody>().mass, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
