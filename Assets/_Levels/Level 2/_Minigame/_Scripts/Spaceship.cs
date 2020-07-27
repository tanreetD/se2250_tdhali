using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{

    public GameManager gameManager;
    public float velocity = 1;
    public Rigidbody2D rb;


    Minigames m = new Minigames();
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
            m.Success();
            m.setFail(false);

        }

        if (rb.transform.position.y <= -5 || rb.transform.position.y >= 5)
        {
            m.Fail();
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cactus")
        { 
            m.Fail();
        }
    }
}