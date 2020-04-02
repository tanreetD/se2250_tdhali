using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Vector2 lastPos;


    // Start is called before the first frame update
    void Awake()
    {
        int xOffset;
        player = GameObject.FindGameObjectWithTag("Alien").transform;
        if (player.transform.position.x - this.transform.position.x > 0)
        {

            xOffset = 15;
            lastPos = new Vector3(player.transform.position.x + xOffset, player.transform.position.y, player.transform.position.z);
        }
        else
        {
            xOffset = -15;
            lastPos = new Vector3(player.transform.position.x + xOffset, player.transform.position.y, player.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, lastPos, speed * Time.deltaTime);
        StartCoroutine(WaitToDestroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
