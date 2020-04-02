using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;


    public void ItemUsage()
    {
        Alien alien = GameObject.FindGameObjectWithTag("Alien").GetComponent<Alien>();
        Progress progress = new Progress();

        // potion
        switch (type)
        {
            case "regen":
                alien.setHealth();
                break;

            case "shrink":
                //make this for only 6 seconds
                Vector3 scale = alien.transform.localScale;
                scale.x *= 0.5f;
                scale.y *= 0.5f;
                alien.transform.localScale = scale;
                alien.jumpPower = 12f;
                break;
            case "extraLife":
                // add extra life
                progress.setLives(progress.getLives() + 1);
                break;
            case "extraPoints":
                //make this for 10 seconds only
                progress.AddScoreCount(500);
                break;
        }
    }
}