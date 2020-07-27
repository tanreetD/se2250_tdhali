using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
   public float min = 2f;
   public float max = 3f;
   public float distance = 3f;
   public float speed = 2f;
    // Use this for initialization
    void Start () {
       
        min = transform.position.x;
        max = transform.position.x + distance;
   
    }
   
    // Update is called once per frame
    void Update () { 
        transform.position =new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);  
    }
}
