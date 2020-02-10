using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColorScript : MonoBehaviour
{

    public GameObject panel;

    public SpriteRenderer head;

    public Color purple;
    public Color blue;
    public Color red;
    public Color yellow;

    public int whatColor = 1;

    void Update(){

        
        if (whatColor == 1){
            head.color = purple;
        } else if(whatColor == 2){
            head.color = blue;
        }
        else if(whatColor == 3){
            head.color = red;
        }
        else if(whatColor == 4){
            head.color = yellow;
        }
    }

    public void OpenPanel(){
        panel.SetActive(true);
    }

    public void ClosePanel(){
        panel.SetActive(false);

    }

    public void changeHeadPurple(){
        whatColor = 1;
    }

    public void changeHeadBlue(){
        whatColor = 2;
    }

    public void changeHeadRed(){
        whatColor = 3;
    }

    public void changeHeadYellow(){
        whatColor = 4;
    }


}
