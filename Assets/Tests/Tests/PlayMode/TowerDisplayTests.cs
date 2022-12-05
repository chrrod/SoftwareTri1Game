using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TowerDisplayTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TowerDisplayTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TowerRotates()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(3.0f);
        GameObject tower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/RocketTower"));
        GameObject bloon = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/RedBloon"));
        Quaternion x = tower.GetComponent<Transform>().rotation;
        yield return new WaitForSeconds(1.0f);
        Assert.AreNotEqual(x, tower.GetComponent<Transform>().rotation);
    }

    [UnityTest]
    public IEnumerator TowerShoots()
    {
        yield return new WaitForSeconds(3.0f);
        GameObject tower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/RocketTower"));
        GameObject bloon = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/RedBloon"));
        yield return new WaitForSeconds(2.0f);
        Assert.IsTrue(bloon==null);
    }

}
