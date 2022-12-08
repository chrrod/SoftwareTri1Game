using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BloonsDisplayTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BloonsDisplayTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BloonsDisplayTestForBloonMovement()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        GameObject[] bloon = GameObject.FindGameObjectsWithTag("Bloon");
        if(bloon.Length>0){
            float x = bloon[0].GetComponent<Transform>().position.y;
            yield return new WaitForSeconds(1.0f);
            Assert.Less(x, bloon[0].GetComponent<Transform>().position.y);
        }
    }
}
