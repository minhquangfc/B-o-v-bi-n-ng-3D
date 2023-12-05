using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
[System.Serializable]
[RequireComponent(typeof(Floater))]
public class Boudary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : ShipController
{
    // Start is called before the first frame update
    public float speed=5f;
    public float steerspeed=3f;
    public float movement = 10f;
    public float tilt = 1f;
    public Boudary boudary;
    float movementFactor;
    float steerFactor;
    float vertical;
    float horizontal;
    public GameObject explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        //MoveMent();
        //Steer();
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        

        GetComponent<Rigidbody>().velocity = direction * speed;
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boudary.xMin, boudary.xMax), 0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boudary.zMin, boudary.zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        Vector3 Gundirection = new Vector3(
            Input.mousePosition.x-Screen.width/2-80 ,0, Input.mousePosition.z + Screen.height / 2-20

            );

        Debug.Log(Gundirection.normalized);
        RotateGun(Gundirection);

        //if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        //{
        //    Shoot();
        //}
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Enemy")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);

            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }
        //void MoveMent()
        //{
        //    //di chuyen theo chieu z


        //    Vector3 newPos = this.transform.position + this.transform.up;
        //    movementFactor = Mathf.Lerp(movementFactor, vertical, Time.deltaTime / movement);
        //    transform.Translate(0f, 0f, movementFactor * speed);


        //}
        //void Steer()
        //{
        //    //xoay theo chieu x

        //    //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        //    //{
        //    steerFactor = Mathf.Lerp(steerFactor, horizontal * vertical, Time.deltaTime / movement);
        //    transform.Rotate(0f, steerFactor * steerspeed, 0f);
        //    //}    

        //}
    }
