using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{

    public GameManager gameManager;
    public float velocity = 1;
    public Rigidbody2D rb;
    public GameObject endGameUI;
    public GameObject winGameUI;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up * velocity;
        }

        if (Score.score == 30)
        {
            winGameUI.SetActive(true);

        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cactus") { 
        endGameUI.SetActive(true);
        Invoke("ReplayGame", 1f);
    }

     
    }

    public void ReplayGame() {
        gameManager.Replay();
    }


}