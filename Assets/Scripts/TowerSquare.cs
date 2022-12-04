using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSquare : MonoBehaviour, IPointerDownHandler
{

    public GameObject eventSystem;
    //public TowerManagement tm;
    public GameObject[] towerPrefabs = new GameObject[5];
    public bool hasTower;

    // Start is called before the first frame update
    void Start()
    {
        //tm = eventSystem.GetComponent<TowerManagement>();
        hasTower = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(hasTower){
            Debug.Log("This space already has a tower");
        }else{
            TowerDisplay td = towerPrefabs[TowerManagement.Instance.getCurrentPos()].GetComponent<TowerDisplay>();
            if(TowerManagement.Instance.getMoney()>=td.cost)
            {
                hasTower = true;
                TowerManagement.Instance.changeMoney(-1*td.cost);
                Instantiate(towerPrefabs[TowerManagement.Instance.getCurrentPos()], transform.position, transform.rotation);
                gameObject.layer = 0;
                Destroy(gameObject);
            }else{
                Debug.Log("Not enough money");
            }
        }
    }
}
