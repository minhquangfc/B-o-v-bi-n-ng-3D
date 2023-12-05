using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    public float ltime;
    void Start()
    {
        Destroy(this.gameObject,ltime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
