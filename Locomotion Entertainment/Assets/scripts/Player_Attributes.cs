using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attributes : MonoBehaviour
{
    [SerializeField]
    private float playerHealth;

    [SerializeField]
    private float playerOxygen;

    [SerializeField]
    private float playerHunger;

    [SerializeField]
    private float playerThirst;

    [SerializeField]
    private float playerTemperature; //????



    void Start()
    {
        playerHealth = 100;
        playerOxygen = 100;
        playerHunger = 100;
        playerThirst = 100;
    }

    void Update()
    {
        
    }
}
