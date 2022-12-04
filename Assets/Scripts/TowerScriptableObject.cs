using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerScriptableObject")]
public class TowerScriptableObject : ScriptableObject
{
    public string towerName; 
    public int range;
    public int damage;
    public int speed;
    public Sprite sprite;
    public int cost;
}
