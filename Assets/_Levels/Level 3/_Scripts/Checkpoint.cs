using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    static bool checkPoint;
    public GameObject checkpointPanel;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            checkPoint = true;
            StartCoroutine(Wait());
        }
    }

    public bool getCheckPoint()
    {
        return checkPoint;
    }

    public void setCheckPoint(bool check)
    {
        checkPoint = check;
    }

    public void StartMinigame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        checkpointPanel.SetActive(true);
    }
}
