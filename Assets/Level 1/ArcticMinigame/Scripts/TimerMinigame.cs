using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerMinigame : MonoBehaviour
{
    private int time = 31;
    public Text timeText;
    public Rigidbody2D alien;
    public GameObject timeUp;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
    }

    AlienMinigame obj = new AlienMinigame();
    void Count()
    {
        if (time == 0)
        {
            CancelInvoke("Count");
            timeUp.SetActive(true);
            StartCoroutine(Wait());
        }
        else
        {
            time--;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        obj.Fail();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = time.ToString();
    }

}
