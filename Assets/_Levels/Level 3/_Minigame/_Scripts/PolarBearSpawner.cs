using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarBearSpawner : MonoBehaviour
{
    public GameObject polarBear;
    public float spawnDelay = 0.3f;
    private float nextSpawnTime = 0f;
    public Transform[] spawnPoints;

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnTime <= Time.time) {
            SpawnPolarBear();
            nextSpawnTime = Time.time + spawnDelay;
            
        }
    }

    void SpawnPolarBear()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(polarBear, spawnPoint.position, spawnPoint.rotation);
    }
}
