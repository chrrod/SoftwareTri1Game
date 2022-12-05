using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerManagement : MonoBehaviour
{
    private static TowerManagement _instance;
    public static TowerManagement Instance{ get { return _instance;}}
    //public Button[] buttons = new Button[5];
    private int currentpos;
    public int money;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        currentpos = 0;
        money = 1000;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if(_instance!= null&&_instance!=this)
        {
            Destroy(this.gameObject);
        }else{
            _instance = this;
        }
    }

    public void setCurrentPos(int x)
    {
        currentpos = x;
    }

    public int getCurrentPos()
    {
        return currentpos;
    }

    public void changeMoney(int x)
    {
       money+=x;
    }

    public int getMoney()
    {
        return money;
    }

    public int getHealth()
    {
        return health;
    }

    public void changeHealth(int x)
    {
        health-=x;
        if(health<=0){
            SceneManager.LoadScene("RetryGame");
        }
    }
}
