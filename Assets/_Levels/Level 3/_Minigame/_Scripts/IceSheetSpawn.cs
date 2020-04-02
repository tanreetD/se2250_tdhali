using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSheetSpawn : MonoBehaviour
{
    public GameObject iceSheet;
    public float spawnDelay = 0.3f;
    private float nextSpawnTime = 0f;
    public Transform[] spawnPoints;

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnTime <= Time.time)
        {
            SpawnIceSheet();
            nextSpawnTime = Time.time + spawnDelay;

        }
    }

    void SpawnIceSheet()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(iceSheet, spawnPoint.position, spawnPoint.rotation);
    }
}
