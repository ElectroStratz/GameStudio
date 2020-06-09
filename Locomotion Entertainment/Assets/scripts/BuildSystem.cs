using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildSystem : MonoBehaviour
{
    private GridSystem grid;
    public NavMeshSurface dynamicNavMesh;
    Camera cameraMain;
    public GameObject buildingBlock;
    //public GameObject buildingReference;
    private GameObject currentPlaceableObject;
    public Vector3 nextPosition;
    public bool isBuilding;

    private float mouseWheelRotation;

    PlayerInv inventory;
    private bool isAllowed;
    Ray ray;

    RaycastHit hitInfo;

    private void Awake()
    {
        grid = FindObjectOfType<GridSystem>();
        isBuilding = false;
        isAllowed = false;
        inventory = GetComponent<PlayerInv>();
        cameraMain = Camera.main;
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        HandleNewObjectHotkey();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Player_Controller.canMove = true;
        }
        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }

    }
    private void HandleNewObjectHotkey()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                Player_Controller.canMove = false;
                currentPlaceableObject = Instantiate(buildingBlock);
            }
        }
           

    }

    private void MoveCurrentObjectToMouse()
    {
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point + Vector3.up * 1f;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        }
    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
           
    }
   public bool GetIsBuilding()
    {
        return this.isBuilding;
    }
}
/*Old Building*/
    /*void Update() { 
         if (isBuilding)
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hitInfo;
             bool hit = Physics.Raycast(ray, out hitInfo);

             ShowSampleCube(ray, hitInfo);
             if (Input.GetMouseButtonDown(0))
             {
                 isAllowed = inventory.RemoveFromInventory("Iron", 5);

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
    }*/

    /* private void ShowSampleCube(Ray ray, RaycastHit hitInfo)
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
         Ray directionClick = cameraMain.ScreenPointToRay(Input.mousePosition);//ray casted from camera prespective
         RaycastHit hitZone;
         Physics.Raycast(directionClick, out hitZone);
         if (hitZone.collider.tag == "BuildingBlock")
         {
             Debug.Log("~Ja tem um bloco aqui boi");
         }
         else
         {
             buildingBlock.transform.position = finalPosition;
             Instantiate(buildingBlock);
             dynamicNavMesh.BuildNavMesh();

         }


     }
     */