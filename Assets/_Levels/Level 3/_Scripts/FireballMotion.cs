using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMotion : MonoBehaviour
{
    public Rigidbody2D fireball;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forward = new Vector2(-transform.right.x, -transform.right.y);
        fireball.MovePosition(fireball.position + forward * Time.fixedDeltaTime * speed);
    }
}
