using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class healthbar : MonoBehaviour
{
    private double maxHealth;
    private double currentHealth;

    public Slider healthbarUI;
    public healthbar (double objectHealth)
    {
        maxHealth = objectHealth;
    }
        
  
  public double CalculateHealth()
    {
        return currentHealth/maxHealth;
    }
    public void updateHealth()
    {
        healthbarUI.value = (float)CalculateHealth();

    }
    public double getCurrentHealth()
    {
        return currentHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth();
        
    }
}
