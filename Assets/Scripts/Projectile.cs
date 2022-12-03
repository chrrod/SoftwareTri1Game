using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject trackingBloon;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Vector3 forwardVector = Vector3.Normalize(trackingBloon.transform.position - transform.position);
        transform.position += forwardVector * Time.deltaTime * 6.0f;
    }
}
