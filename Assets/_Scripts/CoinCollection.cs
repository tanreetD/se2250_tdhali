using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    Progress c = new Progress();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            c.AddScoreCount(10);
            if (c.getCoinCollection() != 100)
            {
                c.setCoinCollection(c.getCoinCollection() + 1); 
            }
            else
            {
                if (c.getLives() < 99)
                {
                    c.setLives(c.getLives() + 1);
                }
                c.setCoinCollection(0);
            }
            Destroy(this.gameObject);
        }
    }
}
