using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            if (SceneManager.GetActiveScene().name == "Level One")
            {
                StartCoroutine(WaitForSceneLoad("Level One - Portal 1"));
            }
            else if (SceneManager.GetActiveScene().name == "Level One - Portal 1")
            {
                StartCoroutine(WaitForSceneLoad("Level One - Post Portal"));
            }
            else if (SceneManager.GetActiveScene().name == "Level One - Post Portal")
            {
                StartCoroutine(WaitForSceneLoad("Level One - Post Portal"));
            }
        }
    }

    private IEnumerator WaitForSceneLoad(string level)
    {
     yield return new WaitForSeconds(1);
     SceneManager.LoadScene(level);

    }
}
