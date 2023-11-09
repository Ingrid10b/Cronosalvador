using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject[] spawnPoints;
    public int maxEnemies = 20;
    private bool spawning;
    public float spawnInterval = 5.0f;

    void Start()
    {
        spawning = false;
        // Llamar a EsperarYActivar después de 10 segundos.
        Invoke("EsperarYActivar", 10f);
    }

    void EsperarYActivar()
    {
        spawning = true;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            EnemySpawnPosition();
            yield return new WaitForSeconds(spawnInterval);
            maxEnemies--;
        }
        spawning = false;
    }

    void EnemySpawnPosition()
    {
        if (maxEnemies != 0)
        {
            int spawnPos = Random.Range(0, spawnPoints.Length);
            Instantiate(EnemyPrefab, spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
        }
    }
}