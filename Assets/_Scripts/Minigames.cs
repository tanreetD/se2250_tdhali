using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigames : MonoBehaviour
{
    static bool fail = true;

    public bool getFail()
    {
        return fail;
    }

    public void setFail(bool set)
    {
        fail = set;
    }

    public void Fail()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Success()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
