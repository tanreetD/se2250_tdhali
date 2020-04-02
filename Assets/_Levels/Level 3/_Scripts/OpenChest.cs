using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    public Animator animator;
    public GameObject jewel;
    public GameObject nextLevelPanel;
    public GameObject jewelSpawn;
    public GameObject[] finalLetters;
    public GameObject text;
    Collider2D coll;

    Checkpoint checkpoint = new Checkpoint();
    Minigames minigames = new Minigames();
    Progress progress = new Progress();


    private void OnCollisionEnter2D(Collision2D other)
    {
        coll = GetComponent<Collider2D>();
        if (other.gameObject.tag == "Alien")
        {
            animator.SetTrigger("Open");
            coll.enabled = false;
            StartCoroutine(Wait());
        }
    }

    public void NextLevel()
    {
        checkpoint.setCheckPoint(false);
        minigames.setFail(true);
        progress.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.25f);
        Instantiate(jewel, jewelSpawn.transform);
        yield return new WaitForSeconds(2.5f);
        text.SetActive(true);
        for (int i = 0; i < finalLetters.Length; i++)
        {
            if (progress.getCollected()[i] == false)
            {
                finalLetters[i].SetActive(true);
            }
        }
        nextLevelPanel.SetActive(true);
    }
}
