using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlienXPos : MonoBehaviour
{
    Transform bar;
    public float offset = 3;

    void Start()
    {
        bar = GameObject.Find("Alien").transform;
    }

    void Update()
    {
        transform.position = new Vector3(bar.position.x - offset, transform.position.y, transform.position.z);
    }
}

