using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienMinigame : MonoBehaviour
{
    public Rigidbody2D alien;
    public GameObject success;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            alien.MovePosition(alien.position + Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            alien.MovePosition(alien.position + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            alien.MovePosition(alien.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            alien.MovePosition(alien.position + Vector2.down);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Polar Bear")
        {
            Debug.Log("YOU FAILED");
            Fail();
        }
        else if (collision.tag == "Water")
        {
            Fail();
        }
        else if (collision.tag == "Wall")
        {
            Fail();
        }
        else if (collision.tag == "Iceberg")
        {
            Fail();
        }
        else if (collision.tag == "Endgame")
        {
            success.SetActive(true);
            Invoke("Success", 1.5f);
        }
        
    }

    public void Fail() {
        SceneManager.LoadScene("Level One - Fail");
    }

    public void Success()
    {
        SceneManager.LoadScene("Level One - Success");
    }
}
