using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawn : MonoBehaviour
{
    public GameObject fireball;
    public float spawnDelay = 3f;
    private float nextSpawnTime = 2.25f;
    public Transform[] spawnPoints;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnFireball", spawnDelay, nextSpawnTime);
    }


    void SpawnFireball()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(fireball, spawnPoint.position, spawnPoint.rotation);
    }
}
