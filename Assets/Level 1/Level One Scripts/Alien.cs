using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{
    public Rigidbody2D alien;
    bool moving = true;
    public float speed = 5f;
    public float slideSpeed = 0.5f;
    public float restartDelay = 2f;
    public float jumpPower = 5f;
    public bool onPlatform = false;
    public float fallHeight = -12f;
    public float healthMinus = 0.33f;
    bool facingRight;
    public Animator animator;
    bool isWaiting = false;
    static bool restart = false;
    public GameObject shootDirection;
    private Slider healthBar;


    private void Start()
    {
        restart = false;
        facingRight = true;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
    }
    
    void FixedUpdate()
    {
        if (moving) {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            Vector3 slide = new Vector3(slideSpeed, 0f, 0f);


            if (moving && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Sliding"))
            {
                if ((Input.GetKey("left shift") || Input.GetKey("right shift")))
                {
                    animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                    Jump();
                    transform.position += move * Time.deltaTime * (speed * 1.25f);
                    Flip(move.x);
                }
                else
                {
                    animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                    Jump();
                    transform.position += move * Time.deltaTime * speed;
                    Flip(move.x);
                }
            }


            if ((Input.GetKey("down") && !isWaiting && (Input.GetAxis("Horizontal").Equals(1) || Input.GetAxis("Horizontal").Equals(-1)))
                || (Input.GetKey("s") && !isWaiting && (Input.GetAxis("Horizontal").Equals(1) || Input.GetAxis("Horizontal").Equals(-1))))
            {
                animator.SetBool("Sliding", true);
                animator.SetBool("Shoot", false);
                if (facingRight)
                {
                    transform.position += slide * Time.deltaTime * speed;
                    StartCoroutine(Wait());
                }
                else {
                    transform.position += -slide * Time.deltaTime * speed;
                    StartCoroutine(Wait());
                }
            }
            else
            {
                animator.SetBool("Sliding", false);
            }

            if (Input.GetKey("space"))
            {
                animator.SetBool("Shoot", true);
            }
            else
            {
                animator.SetBool("Shoot", false);
            }
        }

        if (alien.position.y <= fallHeight)
        {
            Restart();
        }
    }

    void Jump()
    {
        if (!onPlatform && alien.velocity.y == 0)
        {
            onPlatform = true;
        }

        if ((Input.GetKey("up") && onPlatform == true) || (Input.GetKey("w") && onPlatform == true))
        {
            alien.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            onPlatform = false;
        }
    }

    void Flip(float horizontal)
    {
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            Quaternion direction = shootDirection.transform.rotation;
            if (facingRight)
            {
                direction.y = 0f;
            }
            else
            {
                direction.y = 180f;
            }
            shootDirection.transform.rotation = direction;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Sliding") && !isWaiting)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                healthBar.value -= healthMinus;
                if (healthBar.value == 0f)
                {
                    Invoke("Restart", restartDelay);
                    moving = false;
                    animator.SetTrigger("Dying");
                }
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        isWaiting = true;
        yield return new WaitForSeconds(5f);
        isWaiting = false;
    }

    public bool getRestart() {
        return restart;
    }

    public void Restart()
    {
        restart = true;
        Progress resetItems = new Progress();
        resetItems.UpdateLives();
        resetItems.getCollected()[0] = false;
        resetItems.getCollected()[1] = false;
        resetItems.getCollected()[2] = false;
        resetItems.getCollected()[3] = false;
        resetItems.getCollected()[4] = false;
        SaveSystem.SaveProgress(resetItems);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
