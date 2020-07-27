using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public Transform player;
    float scaleX;

    private void Awake()
    {
        scaleX = transform.localScale.x;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Alien").transform;
        Vector3 scale = transform.localScale;

        if (player.transform.position.x - this.transform.position.x > 0)
        {
            scale.x = scaleX;
            transform.localScale = scale;
        }
        else {
            scale.x = -scaleX;
            transform.localScale = scale;
        }
    }
}
