using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDisplay : MonoBehaviour
{
    public TowerScriptableObject towerScriptableObject;
    public SpriteRenderer spriteRenderer;
    public GameObject projectile;
    public CircleCollider2D col; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = towerScriptableObject.sprite;
        gameObject.layer = 10; 
        col = GetComponent<CircleCollider2D>(); 
        col.radius = towerScriptableObject.range/2;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.layer = 1;
    }

    private IEnumerator spawnProjectile(GameObject trackingBloon) {
        while(true){
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Projectile newProjectileScript = newProjectile.GetComponent<Projectile>();
            newProjectileScript.setAim(trackingBloon);
            newProjectileScript.setDamage(towerScriptableObject.damage);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bloon") {
            GameObject trackingBloon = collision.gameObject;
            StartCoroutine(spawnProjectile(trackingBloon));
        }
    }
}
