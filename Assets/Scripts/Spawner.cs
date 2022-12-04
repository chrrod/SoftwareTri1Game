using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    int current_wave = 0;

    public GameObject[] bloonArray = new GameObject[4];
    public float startDelay = 1.0f;
    public float waveRepeatDelay = 5.0f;
    int bloonsPerWave = 20;
    float bloonRepeatDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SendWave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendWave() {
        while (true){
            if (current_wave<=4){
                yield return StartCoroutine(SpawnBloons(bloonsPerWave));
            } else {
                yield return StartCoroutine(SpawnBloons(current_wave * current_wave + 5));
            }
            current_wave+=1;
            yield return new WaitForSeconds(waveRepeatDelay);
        }
    }

    IEnumerator SpawnBloons(int number)
    {
        Debug.Log(number);
        int i = 0;
        while(i < number)
        {
            Debug.Log(i);
            Instantiate(bloonArray[current_wave % 4]);
            i+=1;
            if (current_wave!=0){
                bloonRepeatDelay = 0.5f / current_wave; 
            }
            yield return new WaitForSeconds(bloonRepeatDelay);
        }
    }
}
