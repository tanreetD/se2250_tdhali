using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerSelection : MonoBehaviour
{
    public GameObject[] alienPlayers = new GameObject[3];
    static GameObject player;

    public void Alien1()
    {
        player = alienPlayers[0];
        Continue();
    }

    public void Alien2()
    {
        player = alienPlayers[1];
        Continue();
    }

    public void Alien3()
    {
        player = alienPlayers[2];
        Continue();
    }

    public GameObject getPlayer()
    {
        return player;
    }

    void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
