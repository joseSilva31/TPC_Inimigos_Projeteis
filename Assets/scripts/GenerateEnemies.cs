using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public int numEnemies = 5;

    void Start()
    {
        for(int i = 0; i < numEnemies; i++)
        Instantiate(enemy, new Vector3(Random.Range(-12, 12), Random.Range(-5,5),0), Quaternion.identity);
    }
}
