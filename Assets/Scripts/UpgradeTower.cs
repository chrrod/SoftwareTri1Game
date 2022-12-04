using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UpgradeTower")]
public abstract class UpgradeTower : ScriptableObject
{
    public abstract void Upgrade(GameObject gO);
}
