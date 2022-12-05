using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UITowerDisplayTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void UIDisplayTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator UIDisplayTestWithEnumeratorPasses()
    {
        yield return new WaitForSeconds(3.0f);
        GameObject display = GameObject.Find("/TowersManagement/MenuRect/Canon");
        // UITowerDIsplay x = display.GetComponent<UITowerDIsplay>();
        // x.TowerClicked();
        // yield return new WaitForSeconds(2.0f);
        // Assert.IsTrue(TowerManagement.Instance.getCurrentPos()==1);
    }
}
