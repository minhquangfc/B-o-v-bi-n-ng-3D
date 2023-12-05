using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody bullet;
    public GameObject cursor;//con tro
    public Transform shootpoint;
    public LayerMask layer;
    private Camera cam;
    public GameObject Explosion;
    public GameObject watersplash;
    void Start()
    {
        cam = Camera.main;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        LauchProjectTile();
    }
    void LauchProjectTile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, 300f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point+Vector3.up*0.1f;
            Vector3 Vo = CalculatorVelocity(hit.point, shootpoint.position, 1f);
            transform.rotation = Quaternion.LookRotation(Vo);
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody obj = Instantiate(bullet, shootpoint.position, Quaternion.identity);
                obj.velocity = Vo;
            }    
        }
        else
        {
            cursor.SetActive(false);
        }    
    }
    Vector3 CalculatorVelocity(Vector3 target, Vector3 origin, float time)
    {
        //xác định khoảng cách x và y trước
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;
        //tạo một float đại diện cho khoảng cách
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        //cong thuc vat ly
        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
        
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;
    }
    void OnTriggerEnter(Collider target)
    {
        
        if (target.gameObject.name == "Plane")
        {
            Instantiate(watersplash, target.transform.position, target.transform.rotation);
            Destroy(gameObject);
        }

    }
}
