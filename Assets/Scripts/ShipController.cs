using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ShootC;
    public GameObject bullet;
    public Transform cannon;
    
    protected void Move(Vector3 direction)
    {
        if (direction == Vector3.zero) return;
        if (direction + this.transform.up == Vector3.zero)
        {
            direction += new Vector3(0.5f, 0.5f);
        }
        Vector3 newPos = this.transform.position + this.transform.up;
        this.transform.position = Vector3.Lerp(this.transform.position, newPos, 0.1f);
        this.transform.up = Vector3.Lerp(this.transform.up, direction, 0.1f);
    }
    protected void RotateGun(Vector3 direction)
    {
        cannon.forward = Vector3.Lerp(cannon.up, direction, 0.1f);
        cannon.Rotate(0, 2, 0);
    }

    protected void Shoot()
    {
        
        GameObject objbullet = Instantiate(bullet, ShootC.position, Quaternion.identity);
        objbullet.transform.forward = ShootC.forward;
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
