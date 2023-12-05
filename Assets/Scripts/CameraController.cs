using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(
            playerTransform.position.x,
            70,
            playerTransform.position.z-60);
        this.transform.position = Vector3.Slerp(this.transform.position, newPos, 0.3f);
    }
}
