using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TowerManagementTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TowerManagementTestSimplePasses()
    {
        // Use the Assert class to test conditions

        //GameObject go = GameObject.Find("EventSystem");
        //TowerManagement tm = go.GetComponent<TowerManagement>();
        
        TowerManagement.Instance.setCurrentPos(2);
        Assert.IsTrue(TowerManagement.Instance.getCurrentPos() == 2);
        
        int x = TowerManagement.Instance.getMoney();
        TowerManagement.Instance.changeMoney(25);
        Assert.IsTrue(TowerManagement.Instance.getMoney() == x+25);

        
        x = TowerManagement.Instance.getHealth();
        TowerManagement.Instance.changeHealth(25);
        Assert.IsTrue(TowerManagement.Instance.getHealth() == x-25);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    /*[UnityTest]
    public IEnumerator TowerManagementTestSetPosition()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
    }

    [UnityTest]
    public IEnumerator TowerManagementTestMoney()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame
    }

    [UnityTest]
    public IEnumerator TowerManagementTestHealth()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame
    }*/
}
