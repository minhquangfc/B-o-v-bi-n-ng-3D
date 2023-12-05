using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemyspeed;
    [SerializeField]
    private Rigidbody myBody;
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.velocity = -transform.forward *enemyspeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
