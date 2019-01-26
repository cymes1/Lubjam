using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnthouse : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] enemyPrefabs;
    public float minSpawnTime;
    public float maxSpawnTime;

    private float timeToWave;

    void Start()
    {
        timeToWave = GenerateTimeToWave();
    }

    void Update()
    {
        timeToWave -= Time.deltaTime;
        if(timeToWave < 0)
            CreateWave();
    }

    private float GenerateTimeToWave()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void CreateWave()
    {
        timeToWave = GenerateTimeToWave();
        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoint.position, Quaternion.identity);
    }
}
