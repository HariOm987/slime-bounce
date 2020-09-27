using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int wave;
    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    public GameObject[] enemies;
    public float minTimeSpawns;
    public float maxTimeSpawns;
    public bool canSpawn;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        Invoke("SpawnEnemy", 0.5f);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeBtwSpawns = Random.Range(minTimeSpawns, maxTimeSpawns);
        Instantiate(enemies[Random.Range(0, enemies.Length)],currentPoint.transform.position, Quaternion.identity);
        Invoke("SpawnEnemy", timeBtwSpawns);
    }
}
