using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject trackingBloon;
    public int damage;
    private Vector3 forwardVector;
    // Start is called before the first frame update
    void Start()
    {
        forwardVector = Vector3.Normalize(trackingBloon.transform.position - transform.position);
    }

    public void setAim(GameObject gameObject) {
        trackingBloon = gameObject;
    }

    public void setDamage(int towerDamage) {
        damage = towerDamage; 
    }

    // Update is called once per frame
    void Update()
    {
        // if (trackingBloon==null){
        //     Destroy(gameObject);
        //     return;
        // }
        // Vector3 forwardVector = Vector3.Normalize(trackingBloon.transform.position - transform.position);
        // transform.position += forwardVector * Time.deltaTime * 6.0f;
        if(transform.position.x>5||transform.position.x<-5||transform.position.y>5||transform.position.y<-5)
        {
            Destroy(gameObject);
        }
        if(trackingBloon != null){
            forwardVector = Vector3.Normalize(trackingBloon.transform.position - transform.position);
        }
        transform.position += forwardVector * Time.deltaTime * 6.0f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bloon"&&trackingBloon!=null) {
            Debug.Log("Projectile collision detected");
            BloonDisplay bloon = collision.gameObject.GetComponent<BloonDisplay>();
            bloon.health -= damage;
            Debug.Log(bloon.health);
            if (bloon.health<=0){
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
