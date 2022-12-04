using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UpgradePower")]
public class UpgradePower : UpgradeTower  
{
    // Start is called before the first frame update
    public override void Upgrade(GameObject gO)
    {
       gO.GetComponent<TowerDisplay>().projectile.GetComponent<Projectile>().damage += 1;
    }
}
