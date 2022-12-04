using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewUIDisplay", menuName = "UITower")]
public class UITower : ScriptableObject
{
    public int cost;
    public int upgradeCost;
    public Image towerImage;
    public int pos;
}
