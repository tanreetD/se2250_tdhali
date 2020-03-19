using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D a = player.GetComponent<Alien>().alien;
        if (collision.collider.tag == "Platform" && a.position.y <= 0.001f) {
            player.GetComponent<Alien>().onPlatform = true;
            a.velocity = Vector3.zero;
            a.angularVelocity = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform") {
            player.GetComponent<Alien>().onPlatform = false;
        }
    }
}
