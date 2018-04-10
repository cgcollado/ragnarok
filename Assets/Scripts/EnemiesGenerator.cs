using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour {

    public GameObject[] generator;
    private float minTime;
    private float maxTime;
   // private float time = 0.001f;

    // Use this for initialization
    void Start()
    {
        minTime = 10f;
        maxTime = 30f;
        InvokeRepeating("SpawnEnemy", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {

        Instantiate(generator[Random.Range(0, generator.Length)], this.transform.position, Quaternion.identity);
        Debug.Log("new enemy");

    }
}
