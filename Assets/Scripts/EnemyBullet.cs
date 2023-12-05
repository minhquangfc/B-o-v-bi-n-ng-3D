using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject Explosion;
    public GameObject explosion;
    private int timeCount = 0;
    void Start()
    {
        
        GetComponent<Rigidbody>().velocity = -transform.forward * speed;
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(target.gameObject);
            Destroy(this.gameObject);
            MainMenuController.instance.ShipDiedShowPanel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        timeCount += 1;
        if (timeCount == 25)
        {
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
            //Instantiate(Explosion, this.transform.position+new Vector3(0,1,0), this.transform.rotation);
            IeExplosion();
            Destroy(this.gameObject);
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
