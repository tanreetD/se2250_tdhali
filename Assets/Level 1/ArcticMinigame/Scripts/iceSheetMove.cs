using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceSheetMove : MonoBehaviour
{
    public Rigidbody2D iceSheet;
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
        Vector2 backwards = new Vector2(-transform.right.x, -transform.right.y);
        iceSheet.MovePosition(iceSheet.position + backwards * Time.fixedDeltaTime * speed);
    }
}
