using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] items;
    public Transform[] spawnPoints;
    Vector3 revertScale;

    Progress progress = new Progress();


    public void Awake()
    {
        Alien alien = GameObject.FindGameObjectWithTag("Alien").GetComponent<Alien>();
        revertScale = alien.transform.localScale;

        if (progress.getLives() < 6)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                spawnPoints[i] = GameObject.FindGameObjectWithTag("Spawn" + i.ToString()).GetComponent<Transform>();
            }
            Instantiate(items[0], spawnPoints[0]);
            Instantiate(items[1], spawnPoints[1]);
            Instantiate(items[2], spawnPoints[2]);
            Instantiate(items[3], spawnPoints[3]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Alien alien = GameObject.FindGameObjectWithTag("Alien").GetComponent<Alien>();
        alien.transform.localScale = revertScale;
        alien.jumpPower = 10.8f;

        Destroy(this.GetComponent<BoxCollider2D>());
    }
}
