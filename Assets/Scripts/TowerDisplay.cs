using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDisplay : MonoBehaviour
{
    public TowerScriptableObject towerScriptableObject;
    public SpriteRenderer spriteRenderer;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = towerScriptableObject.sprite;
        gameObject.layer = 10; 
        StartCoroutine(spawnProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.layer = 1;
    }

    private IEnumerator spawnProjectile() {
        while(true){
            Instantiate(projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(1);
        }
    }
}
