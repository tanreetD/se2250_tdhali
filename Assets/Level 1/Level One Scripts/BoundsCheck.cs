using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    //radius that changes boundary on screen
    public float radius = 1f;
    //determines whether object stays on screen or not
    public bool keepOnScreen = true;

    [Header("Set Dyncamically")]
    //boolean that is trrue if object is on screen
    public bool onScreen = true;
    //float variables that will hold the camera width and height
    public float camWidth;
    public float camHeight;

    [HideInInspector]
    //booleans that is true if object is off right, off left, off up, or off down respectively
    public bool offRight, offLeft, offUp, offDown;

    private void Awake()
    {
        //setting the camHeight and camWidth
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        onScreen = true;
        offRight = offLeft = offUp = offDown = false;
        //if statement that 
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        if (pos.y > camWidth - radius)
        {
            pos.y = camWidth - radius;
            offUp = true;
        }
        if (pos.y < -camWidth + radius)
        {
            pos.y = -camWidth + radius;
            offDown = true;
        }

        onScreen = !(offRight || offLeft || offUp || offDown);
        if (keepOnScreen && !onScreen)
            transform.position = pos;
        onScreen = true;
        offRight = offLeft = offUp = offDown = false;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
