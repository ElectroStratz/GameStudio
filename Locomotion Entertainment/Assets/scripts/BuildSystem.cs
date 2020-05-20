﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    private GridSystem grid;

    public GameObject buildingBlock;
    public GameObject buildingReference;
    public Vector3 nextPosition;
    public bool isBuilding;
    
    PlayerInv inventory;
    private bool isAllowed;


    private void Awake()
    {
        grid = FindObjectOfType<GridSystem>();
        isBuilding = false;
        isAllowed = false;
        inventory = GetComponent<PlayerInv>();
    }

    private void Update()
    {
        if (isBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(ray, out hitInfo);

            ShowSampleCube(ray, hitInfo);
            if (Input.GetMouseButtonDown(0))
            {
                isAllowed = inventory.RemoveFromInventory("iron", 5);

                if (hit && isAllowed)
                {
                    PlaceCubeNear(hitInfo.point);
                    
                    
                }
            }
        }
        else
        {
            GameObject referenceBlock = GameObject.FindWithTag("BuildReference");
            if (referenceBlock != null)
            {
                GameObject.Destroy(referenceBlock,0);
            }
        }
    }

    private void ShowSampleCube(Ray ray, RaycastHit hitInfo)
    {
        nextPosition = grid.GetNearestPointOnGrid(hitInfo.point);
        GameObject referenceBlock = GameObject.FindWithTag("BuildReference");

        if (referenceBlock != null)
        {
            referenceBlock.transform.position = nextPosition;
        }
        else
        {
            buildingReference.transform.position = nextPosition;
            Instantiate(buildingReference);
        }

    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        buildingBlock.transform.position = finalPosition;
        Instantiate(buildingBlock);
    }

    public bool GetIsBuilding()
    {
        return this.isBuilding;
    }
}
