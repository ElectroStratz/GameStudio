using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Attributes : MonoBehaviour
{
    [SerializeField]
    private float playerHealth;
    private float currentHealth;
    public float currentOxygen;

    [SerializeField]
    private float playerOxygen;

    [SerializeField]
    private Image healthUI;

    [SerializeField]
    private Image oxygenUI;


    void Start()
    {
        playerHealth = 100;
        playerOxygen = 100;
        currentHealth = playerHealth;
        currentOxygen = playerOxygen;
        InvokeRepeating("OxygenLoss", 1, 3);
    }

    void Update()
    {
        //Testing UI
        if (currentOxygen <= 0)
        {
            TakeDamage();
        }
                                                                                                                                            
    }

    void TakeDamage()
    {
        currentHealth --;
        healthUI.fillAmount = currentHealth / playerHealth;
    }

    void OxygenLoss()
    {
        if(currentOxygen > 0)
        {
            currentOxygen -= 1f;
            oxygenUI.fillAmount = currentOxygen / playerOxygen;
        }
    }
}
