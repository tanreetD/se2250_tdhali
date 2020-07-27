using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool[] saveCollected;
    public int lives;
    public int score;
    public int coins;

    public PlayerData(Progress progress)
    {
        saveCollected = progress.getCollected();
        lives = progress.getLives();
        score = progress.getScoreCount();
        coins = progress.getCoinCollection();
    }
}
