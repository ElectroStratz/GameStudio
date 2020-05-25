﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSystem : MonoBehaviour
{
    public static GrowSystem instance;
    private float growth;
    public PlantingSystem plantingScript;
    [SerializeField]
    public bool isPlanted = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (isPlanted)
        {
            InvokeRepeating("Growth", 5, 5);
        }
    }
    void Growth()
    {
        gameObject.transform.localScale = new Vector3(0.2f, transform.localScale.y + 1f, 0.2f);
        growth++;
    }

    void OnMouseDown()
    {
        if (growth == 5)
        {
            plantingScript = gameObject.GetComponentInParent<PlantingSystem>();
            plantingScript.isOccupied = false;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Cant harvest yet!");
        }

    }
}
