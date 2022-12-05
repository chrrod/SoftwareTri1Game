using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDisplay : MonoBehaviour, IPointerDownHandler
{
    public TowerScriptableObject towerScriptableObject;
    public SpriteRenderer spriteRenderer;
    public GameObject projectile;
    public CircleCollider2D col; 
    public int upgradeCost;
    public bool hasUpgrade;
    public UpgradeTower upgrade;
    public float speed;

    List<GameObject> bloonsList = new List<GameObject>();
    public GameObject trackingBloon;
    Coroutine spawnCoroutine;
    public float rotationSpeed;
    public float rotationModifier;
    public int cost;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = towerScriptableObject.sprite;
        cost = towerScriptableObject.cost;
        gameObject.layer = 10; 
        col = GetComponent<CircleCollider2D>(); 
        col.radius = towerScriptableObject.range/2;
        rotationSpeed = 100;
        speed = towerScriptableObject.speed;
        damage = towerScriptableObject.damage;
        upgradeCost = towerScriptableObject.upgradeCost;
        rotationModifier  = 0;
        hasUpgrade = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.layer = 1;
        if (trackingBloon!=null){
            directionToLookAt();
        }
    }

    private IEnumerator spawnProjectile() 
    {
        while(true){
            yield return new WaitForSeconds(speed);
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Projectile newProjectileScript = newProjectile.GetComponent<Projectile>();
            newProjectileScript.setAim(trackingBloon);
            newProjectileScript.setDamage(damage);
            if (trackingBloon == null)
            {
                StopCoroutine(spawnCoroutine);
                break;
            }
        }
    }

    void directionToLookAt(){
        if(trackingBloon!=null){
            Vector3 vectorToTarget = trackingBloon.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg-rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime*rotationSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if ((collision.gameObject.tag == "Bloon")) {
            bloonsList.Add(collision.gameObject);
            if (trackingBloon==null){
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if(TowerManagement.Instance.getMoney()>=upgradeCost&&!hasUpgrade){
            upgrade.Upgrade(gameObject);
            TowerManagement.Instance.changeMoney(-1*upgradeCost);
            hasUpgrade = true;
            Debug.Log("Upgraded");
        }
    }
}
