using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        //if(other.tag=="Player")
        //{
        //    MainMenuController.instance.ShipDiedShowPanel();
        //}    
    }
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
}
