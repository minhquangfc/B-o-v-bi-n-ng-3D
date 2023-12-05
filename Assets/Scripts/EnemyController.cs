using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ShipController

{
    // Start is called before the first frame update
    public float enemyspeed;
    [SerializeField]
    private Rigidbody myBody;
    float movementFactor;
    public GameObject explosion;
    void Start()
    {
        //myBody = GetComponent<Rigidbody>();
        
        //Vector3 newPos = this.transform.position + this.transform.up;
        
        
        StartCoroutine(EnemyShoot());
        
    }

    // Update is called once per frame
    void Update()
    {
         
        


    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            MainMenuController.instance.ShipDiedShowPanel();
        }
    }
    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(Random.Range(2f, 3f));
        Vector3 temp = transform.position;
        temp.y += 2f;
        Instantiate(bullet, temp, Quaternion.identity);
        
        StartCoroutine(EnemyShoot());
    }
}
