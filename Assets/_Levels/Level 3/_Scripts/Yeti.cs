using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : MonoBehaviour
{


    public float timeBtwShoots;
    public float startTimeBtwShoots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwShoots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
