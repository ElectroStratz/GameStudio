﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSystem : MonoBehaviour
{
    private PlayerInv inventory;
    private GameObject manager;
    private GameObject _player;
    private Animator _playeranimator;
    public static GrowSystem instance;
    private float growth;
    public PlantingSystem plantingScript;
    [SerializeField]
    public bool isPlanted = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        manager = GameObject.FindGameObjectWithTag("GameManager");
        _player = GameObject.FindGameObjectWithTag("Player");
        _playeranimator = _player.GetComponentInChildren<Animator>();
        inventory = manager.GetComponent<PlayerInv>();
        if (isPlanted)
        {
            plantingScript = gameObject.GetComponentInParent<PlantingSystem>();
                InvokeRepeating("Growth", 1, 5);


        }
    }
    void Growth()
    {
        if (growth < 5)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 1f, transform.localScale.z);
        growth++;
        }
            else
        {
            Debug.Log("Ready to Harvest");
        }
    }

    void OnMouseDown()
    {
        if (growth == 5)
        {
            _playeranimator.SetTrigger("Pick");
            plantingScript.isOccupied = false;
            Destroy(gameObject);
            inventory.AddToInventory("food", 3, null);
        }
        else
        {
            Debug.Log("Cant harvest yet!");
        }

    }
}
