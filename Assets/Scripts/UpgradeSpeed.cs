using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UpgradeSpeed")]
public class UpgradeSpeed : UpgradeTower
{
    // Start is called before the first frame update
    public override void Upgrade(GameObject gO)
    {
        gO.GetComponent<TowerDisplay>().speed -=1;
    }
}
