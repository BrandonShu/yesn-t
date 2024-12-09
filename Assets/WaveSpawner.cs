using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    float enemiesToSpawn = 3;

    EnemyManager m_EnemyManager;

    bool spawningEnemies = false;

    public Transform[] spawnPoints;

    public GameObject enemyPrefab;

    public int currentWave = 0;


    void Awake()
    {
        m_EnemyManager = GameObject.FindObjectOfType<EnemyManager>();
    }

    void Update()
    {
        if (m_EnemyManager.Actors.Count == 0)
        {
            StartCoroutine(NextWave());
        }

    }

    IEnumerator NextWave()
    {
        spawningEnemies = true;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return null;// new WaitForSeconds(0.5f); // Spawn delay between enemies
        }
        currentWave++;
        enemiesToSpawn += 3;
        spawningEnemies = false;
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            UnityEngine.Debug.LogError("No spawn points assigned!");
            return;
        }

        // Pick a random spawn point
        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

        // Instantiate the enemy
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Add the new enemy to the list of alive enemies
        //m_EnemyManager.Actors.Add(enemy);

    }


}
