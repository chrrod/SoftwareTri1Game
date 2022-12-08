using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ProjectileTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ProjectileTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ProjectileTestDestorysItselfAndBloon()
    {
        yield return new WaitForSeconds(3.0f);
        GameObject projectile = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Rocket"));
        GameObject bloon = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/RedBloon"));
        projectile.GetComponent<Transform>().position = bloon.GetComponent<Transform>().position;
        yield return new WaitForSeconds(2.0f);
        Assert.IsTrue(projectile==null&&bloon==null);
    }
}
