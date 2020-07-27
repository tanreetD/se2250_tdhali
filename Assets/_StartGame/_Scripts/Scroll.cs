﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    float scrollSpeed = -2f;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat (Time.time * scrollSpeed, 20);
        transform.position = startPos + Vector2.right * newPos;
    }
}
