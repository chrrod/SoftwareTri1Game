using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerDisplay : MonoBehaviour
{

    public UITower uit;
    public int cost;
    public int upgradeCost;
    public Button button;
    public GameObject gameManager;
    public int pos;
    public TowerManagement tm;

    // Start is called before the first frame update
    void Start()
    {
        cost = uit.cost;
        upgradeCost = uit.upgradeCost;
        pos = uit.pos;
        tm = gameManager.GetComponent<TowerManagement>();
        button.onClick.AddListener(TowerClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TowerClicked()
    {
        tm.setCurrentPos(pos);
    }
}
