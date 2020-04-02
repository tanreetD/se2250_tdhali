using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject[] alienPlayers = new GameObject[3];
    static GameObject player;


    public void AlienChoice(string alien)
    {
        switch (alien)
        {
            case "playerOne":
                 player = alienPlayers[0];
                break;
            case "playerTwo":
                player = alienPlayers[1];
                break;
            case "playerThree":
                 player = alienPlayers[2];
                break;
        }
        Continue();
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
