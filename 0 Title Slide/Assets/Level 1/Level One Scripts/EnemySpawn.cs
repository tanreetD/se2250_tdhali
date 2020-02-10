using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class EnemySpawn : MonoBehaviour

{

    public GameObject prefab;

    public Vector3 center;

    public Vector3 size;



    // Update is called once per frame

    void Update()

    {
        //switch statement for spawning 5 objects at a time and resetting after objects reset to 0
        switch (GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            case 1:
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        RandomSpawn();
                    }
                }
                break;
        }
    }

    //function for random spawn of pickup objects
    private void RandomSpawn()
    {
            Vector3 position = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(prefab, position, Quaternion.identity);
    }

}