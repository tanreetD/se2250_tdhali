using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public GameObject[] letters = new GameObject[5];
    static bool[] collected = new bool[5];
    public GameObject bar;
    public GameObject letter;
    static int lives = 5;
    public Text livesOnScreen;


    private void Start()
    {
        LoadItemCollection();
    }

    public void UpdateLives()
    {
        Alien a = new Alien();
        if (a.getRestart() && lives > 0) {
            lives--;
            SaveItemCollection();
        }
        if (lives == 0)
        {
            lives = 5;
            SaveItemCollection();
        }
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
            setCollected(collected);
            SaveItemCollection();
            Destroy(this.gameObject);
            
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

    public void SaveItemCollection()
    {
        SaveSystem.SaveProgress(this);
    }

    public void LoadItemCollection()
    {
        PlayerData data = SaveSystem.LoadProgress();
        collected = data.saveCollected;
        lives = data.lives;
        bar.SetActive(true);

        for(int i = 0; i < letters.Length; i++)
        {
           if (collected[i] == true)
            {
                letters[i].SetActive(true);
            }
        }
        livesOnScreen.text = "x" + lives.ToString();
    }
}
