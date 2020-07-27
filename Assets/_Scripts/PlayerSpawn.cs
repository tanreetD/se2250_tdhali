using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class PlayerSpawn : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    private GameObject spawnPoint;
    public GameObject levelObject;

    PlayerSelection ps = new PlayerSelection();

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        Checkpoint c = new Checkpoint();
        Minigames m = new Minigames();

        if (!c.getCheckPoint() && m.getFail())
        {
            spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
            GameObject player = Instantiate(ps.getPlayer(), spawnPoint.transform);
            vcam.m_Follow = player.transform;
        }

        else if (c.getCheckPoint() && m.getFail())
        {
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnCheckpoint");
            GameObject player = Instantiate(ps.getPlayer(), spawnPoint.transform);
            vcam.m_Follow = player.transform;
        }

        else if (c.getCheckPoint() && !m.getFail())
        {
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnFinish");
            GameObject player = Instantiate(ps.getPlayer(), spawnPoint.transform);
            vcam.m_Follow = player.transform;

            switch (scene.name)
            {
                case "Level 1":
                    GameObject.FindGameObjectWithTag("Panda").GetComponent<Collider2D>().enabled = false;
                    GameObject.FindGameObjectWithTag("Panda").GetComponent<SpriteRenderer>().flipX = true;
                    break;
                case "Level 2":
                    GameObject.FindGameObjectWithTag("Elephant").GetComponent<Collider2D>().enabled = false;
                    GameObject.FindGameObjectWithTag("Elephant").GetComponent<SpriteRenderer>().flipX = true;
                    break;
                case "Level 3":
                    GameObject.FindGameObjectWithTag("Wolf").GetComponent<Collider2D>().enabled = false;
                    GameObject.FindGameObjectWithTag("Wolf").GetComponent<SpriteRenderer>().flipX = true;
                    Instantiate(levelObject);
                    break;
            }
        }
    }
}

