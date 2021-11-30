using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float xSpawnRange = 11.5f;
    private float zSpawnRange = 8.0f;
    private float ySpawn = 0.75f;
    private int spawnExtra = 5;

    private float startDelay = 1.0f;
    private float enemyRespawnTime = 3.0f;
    private float powerupRespawnTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemyRespawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupRespawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float randomZ;
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int verticle = Random.Range(0, 2);
        Debug.Log(verticle);

        if (verticle == 0)
        {
            randomZ = Random.Range(zSpawnRange, zSpawnRange + spawnExtra);
        }
        else
        {
            randomZ = Random.Range(-zSpawnRange - spawnExtra, -zSpawnRange);
        }

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
        int randomEnemy = Random.Range(0, enemies.Length);

        Instantiate(enemies[randomEnemy], spawnPos, enemies[randomEnemy].transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomZ = Random.Range(-zSpawnRange + 2, zSpawnRange - 2);
        Vector3 spawnPos = new Vector3(xSpawnRange, ySpawn, randomZ);
        Instantiate(powerup, spawnPos, powerup.transform.rotation);
    }
}
