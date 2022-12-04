using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDisplay : MonoBehaviour
{
    public TowerScriptableObject towerScriptableObject;
    public SpriteRenderer spriteRenderer;
    public GameObject projectile;
    public BoxCollider2D col; 

    List<GameObject> bloonsList = new List<GameObject>();
    public GameObject trackingBloon;
    Coroutine spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = towerScriptableObject.sprite;
        gameObject.layer = 10; 
        col = GetComponent<BoxCollider2D>(); 
        col.size = new Vector2(towerScriptableObject.range, towerScriptableObject.range);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.layer = 1;
    }

    private IEnumerator spawnProjectile() {
        while(true){
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Projectile newProjectileScript = newProjectile.GetComponent<Projectile>();
            newProjectileScript.setAim(trackingBloon);
            newProjectileScript.setDamage(towerScriptableObject.damage);
            yield return new WaitForSeconds(0.3f);
            if (trackingBloon == null){
                StopCoroutine(spawnCoroutine);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if ((collision.gameObject.tag == "Bloon")) {
            Debug.Log("COLLISION OCCURRED");
            bloonsList.Add(collision.gameObject);
            if (trackingBloon==null){
                Debug.Log("TRACKING BLOON IS NULL");
                trackingBloon = collision.gameObject;
                spawnCoroutine = StartCoroutine(spawnProjectile());
            }
        }
    }

    private int FindLastBloon(List<GameObject> bloonsList) {
        int last = 0;
        float lastTime = bloonsList[0].GetComponent<BloonDisplay>().timeElapsed; 
        for (int i=0; i<bloonsList.Count; i++){
            float iTime = bloonsList[i].GetComponent<BloonDisplay>().timeElapsed;
            if (iTime>lastTime){
                lastTime = iTime;
                last = i;
            }
            
        }
        return last;
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject == trackingBloon) {
            if (bloonsList.Count==0){
                trackingBloon = null;
            } else {
                int lastBloon = FindLastBloon(bloonsList);
                trackingBloon = bloonsList[lastBloon];
                bloonsList.RemoveAt(lastBloon);
            }
        } else {
            for (int i=0; i<bloonsList.Count; i++){
                if (bloonsList[i]==other.gameObject){
                    bloonsList.RemoveAt(i);
                }
            }
        }
    }
}
