using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class experiencebar : MonoBehaviour
{
    private int currentXP;
    private int levelUpXP;
    public Slider experiencebarUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void addXP(int gainedXP)
    {
        currentXP += gainedXP;
        if(currentXP >= levelUpXP){
            currentXP = 0;
            levelUpXP += 100;
        }
    }
    public int CalculateExperience()
    {
        return currentXP / levelUpXP;
    }

    // Update is called once per frame
    void Update()
    {
        experiencebarUI.value = (float)CalculateExperience();
    }
}
