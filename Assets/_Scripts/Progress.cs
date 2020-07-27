using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    public GameObject[] letters = new GameObject[5];
    static bool[] collected = new bool[5];

    public GameObject bar;
    public GameObject letter;
    public Slider xpBar;
    static int lives = 10;
    public Text livesOnScreen;
    public Text scoreOnScreen;
    public Text coinsOnScreen;
    static int scoreCount = 0;
    static int coinCollection = 0;


    private void Start()
    {
        LoadItemCollection();
        xpBar = GameObject.FindGameObjectWithTag("XP").GetComponent<Slider>();
    }

    private void Update()
    {
        if (lives < 1)
        {
            lives = 10;
            Reset();
            if (SceneManager.GetActiveScene().name != "Level 1")
            {
                SaveItemCollection();
                SceneManager.LoadScene("Level 1");
            }
        }

        livesOnScreen.text = "x" + lives.ToString();
        scoreOnScreen.text = "SCORE: " + scoreCount.ToString();
        coinsOnScreen.text = "x" + coinCollection.ToString();

        xpBar.value = scoreCount / 10000f;
    }

    public void UpdateLives()
    {
        Alien a = new Alien();
        if (a.getRestart() && lives > 0) {
            lives--;
            SaveItemCollection();
        }
    }

    public void setCollected(bool[] collection)
    {
        collected = collection;
    }

    public bool[] getCollected()
    {
        return collected;
    }

    public void setLives(int l)
    {
        lives = l;
    }

    public int getLives()
    {
        return lives;
    }

    public int getScoreCount()
    {
        return scoreCount;
    }

    public void AddScoreCount(int score)
    {
        scoreCount += score;
    }

    public int getCoinCollection()
    {
        return coinCollection;
    }

    public void setCoinCollection(int coin)
    {
        coinCollection = coin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            bar.SetActive(true);
            switch (letter.gameObject.tag)
            {
                case "A":
                    letters[0].SetActive(true);
                    collected[0] = true;
                    break;
                case "L":
                    letters[1].SetActive(true);
                    collected[1] = true;
                    break;
                case "I":
                    letters[2].SetActive(true);
                    collected[2] = true;
                    break;
                case "E":
                    letters[3].SetActive(true);
                    collected[3] = true;
                    break;
                case "N":
                    letters[4].SetActive(true);
                    collected[4] = true;
                    break;
            }
            SaveItemCollection();
            Destroy(this.gameObject);
        }
    }

    public void SaveItemCollection()
    {
        SaveSystem.SaveProgress(this);
    }

    public void LoadItemCollection()
    {
        PlayerData data = SaveSystem.LoadProgress();
        collected = data.saveCollected;
        lives = data.lives;
        scoreCount = data.score;
        coinCollection = data.coins;
        bar.SetActive(true);

        for(int i = 0; i < letters.Length; i++)
        {
            if (collected[i] == true)
            {
                letters[i].SetActive(true);
            }
        }
    }

    public void Reset()
    {
        collected[0] = false;
        collected[1] = false;
        collected[2] = false;
        collected[3] = false;
        collected[4] = false;
        SaveSystem.SaveProgress(this);
    }

    public void FullReset()
    {
        collected[0] = false;
        collected[1] = false;
        collected[2] = false;
        collected[3] = false;
        collected[4] = false;

        coinCollection = 0;
        scoreCount = 0;
        lives = 10;
        SaveSystem.SaveProgress(this);
    }
}
