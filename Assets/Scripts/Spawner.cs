using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    

    public GameObject[] bloonArray = new GameObject[4];
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBloon", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBloon()
    {
        Instantiate(bloonArray[Random.Range(0, bloonArray.Length)]);
    }
}
