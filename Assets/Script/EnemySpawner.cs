using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject enemy;

    private int spawnPointsQuantity = 0;
    void Start()
    {
        spawnPointsQuantity = transform.childCount;
        InvokeRepeating("EnemySpawn", spawnRate, spawnRate);
    }

    private void EnemySpawn()
    {
        
        int spawnPoint = Random.Range(0, spawnPointsQuantity);
        Instantiate(enemy, transform.GetChild(spawnPoint).position, Quaternion.identity);
    }
}
