using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonSpawner : MonoBehaviour
{
    public GameObject bloon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBloon());
    }
    private IEnumerator spawnBloon() {
        while(true){
            Instantiate(bloon, transform.position, transform.rotation);
            yield return new WaitForSeconds(1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
