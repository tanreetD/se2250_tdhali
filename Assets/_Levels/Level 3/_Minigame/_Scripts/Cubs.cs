using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cubs : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Debug.Log("SUCCESS!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
