using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Attributes : MonoBehaviour
{
    [SerializeField]
    private float playerHealth;
    private float currentHealth;
    private float currentOxygen;

    [SerializeField]
    private float playerOxygen;

    [SerializeField]
    private float playerHunger;

    [SerializeField]
    private float playerThirst;

    [SerializeField]
    private Image healthUI;

    [SerializeField]
    private Image oxygenUI;

    [SerializeField]
    private float playerTemperature; //????

    void Start()
    {
        playerHealth = 100;
        playerOxygen = 100;
        playerHunger = 100;
        playerThirst = 100;
        //Game Manager Perhaps
        currentHealth = playerHealth;
        currentOxygen = playerOxygen;
        InvokeRepeating("OxygenLoss", 10, 10);
    }

    void Update()
    {
        //Testing UI
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage();
        }
                                                                                                                                            
    }

    void TakeDamage()
    {
        currentHealth -= 1f;
        healthUI.fillAmount = currentHealth / playerHealth;
    }

    void OxygenLoss()
    {
        currentOxygen -= 1f;
        oxygenUI.fillAmount = currentOxygen / playerOxygen;
    }
}
