using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSquare : MonoBehaviour, IPointerDownHandler
{

    public GameObject eventSystem;
    public TowerManagement tm;
    public GameObject[] towerPrefabs = new GameObject[5];
    public bool hasTower;

    // Start is called before the first frame update
    void Start()
    {
        tm = eventSystem.GetComponent<TowerManagement>();
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
            hasTower = true;
            Instantiate(towerPrefabs[tm.currentpos], transform.position, transform.rotation);
        }
    }
}
