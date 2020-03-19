using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerSpawn : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    private GameObject spawnPoint;

    PlayerSelection ps = new PlayerSelection();

    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
        GameObject player = Instantiate(ps.getPlayer(), spawnPoint.transform);
        vcam.m_Follow = player.transform;
    }
}
