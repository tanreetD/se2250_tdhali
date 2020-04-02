using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour {

    public enum GameState
    {
        PLAY, PACMAN_DYING, PACMAN_DEAD, GAME_OVER, GAME_WON
    };
    public GameState gameState = GameState.PLAY;

    public GameObject player;
    public AnimationClip playerDeathAnimation;
    public List<GameObject> ghosts;
    public List<GameObject> pills;

    private static GameManager1 instance;
    private float respawnTime;

    Minigames minigames = new Minigames();

	// Use this for initialization
	void Start () {
		if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		switch (gameState)
        {
            case GameState.PLAY:
                bool foundPill = false;
                foreach (GameObject pill in pills)
                {
                    if (pill.activeSelf)
                    {
                        foundPill = true;
                        break;
                    }
                }
                if (!foundPill)
                {
                    minigames.setFail(false);
                    minigames.Success();
                    gameState = GameState.GAME_WON;
                }
                break;
            case GameState.PACMAN_DYING:
                if (Time.time > respawnTime)
                {
                    gameState = GameState.PACMAN_DEAD;
                    respawnTime = Time.time + 1;
                    player.SetActive(false);
                }
                break;
            case GameState.PACMAN_DEAD:
                if (Time.time > respawnTime)
                {
                    gameState = GameState.PLAY;
                    player.SetActive(true);
                    PlayerController playerController = player.GetComponent<PlayerController>();
                    playerController.setLivesLeft(playerController.livesLeft - 1);
                    if (playerController.livesLeft >= 0)
                    {
                        playerController.setAlive(true);
                    }
                    else
                    {
                        gameState = GameState.GAME_OVER;
                    }
                    player.transform.position = Vector2.zero;
                    foreach (GameObject ghost in ghosts)
                    {
                        ghost.GetComponent<GhostController>().reset();
                    }
                }
                break;
            case GameState.GAME_OVER:
                minigames.Fail();
                
                if (Input.anyKeyDown)
                {
                    resetGame();
                    gameState = GameState.PLAY;
                }
                break;
            case GameState.GAME_WON:
                if (Input.anyKeyDown)
                {
                    resetGame();
                    gameState = GameState.PLAY;
                }
                break;
        }
	}

    public static void pacmanKilled()
    {
        instance.player.GetComponent<PlayerController>().setAlive(false);
        instance.gameState = GameState.PACMAN_DYING;
        instance.respawnTime = Time.time + instance.playerDeathAnimation.length;
        foreach (GameObject ghost in instance.ghosts)
        {
            ghost.GetComponent<GhostController>().freeze(true);
        }
    }

    public void resetGame()
    {
        player.transform.position = Vector2.zero;
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.setLivesLeft(2);
        playerController.setAlive(true);
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<GhostController>().reset();
        }
        foreach (GameObject pill in pills)
        {
            pill.SetActive(true);
        }
    }
}
