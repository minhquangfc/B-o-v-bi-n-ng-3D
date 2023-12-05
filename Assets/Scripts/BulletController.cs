using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject Explosion;
    public GameObject watersplash;
    //public GameObject cursor;
    private int timeCount = 0;

    //public int scoreValue;
    //public MainMenuController mainMenuController;
    
    public LayerMask layer;
    public Transform shootpoint;
    public Rigidbody bullet;
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        
    }
    
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Enemy")
        {
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
            
            Destroy(target.gameObject);
            Destroy(gameObject);
            MainMenuController.instance.score++;
        }
        else if (target.tag == "Plane")
        {
            
            Instantiate(watersplash, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

        timeCount += 1;
        if (timeCount == 200)
        {

            //Instantiate(Explosion, this.transform.position, this.transform.rotation);
            //Instantiate(Explosion, this.transform.position+new Vector3(0,1,0), this.transform.rotation);
            IeExplosion();
            Destroy(gameObject);
        }
    }
    
    
    IEnumerator IeExplosion()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
        }
        Destroy(this.gameObject);
    }
      
}
