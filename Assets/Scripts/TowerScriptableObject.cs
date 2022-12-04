using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerScriptableObject")]
public class TowerScriptableObject : ScriptableObject
{
    public string towerName; 
    public int range;
    public int damage;
    public float speed;
    public Sprite sprite;
    public int cost;
    public int upgradeCost;
}
