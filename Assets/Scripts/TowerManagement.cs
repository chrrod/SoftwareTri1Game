using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManagement : MonoBehaviour
{

    //public Button[] buttons = new Button[5];
    public int currentpos;
    public int money;

    // Start is called before the first frame update
    void Start()
    {
        currentpos = 0;
        money = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCurrentPos(int x)
    {
        currentpos = x;
    }
}
