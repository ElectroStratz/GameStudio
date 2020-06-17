using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour
{
    RobotInv _robotInv;

    Camera cameraMain;
    NavMeshAgent player;
    Vector3 direction;
    Animator animator;
    public GameObject gameManager;
    private BuildSystem builder;

    private float speed = 3.5f;
    private float rotationSpeed = 100.0f;
    private bool hit = false;
    private string objectTag;

    public static bool canMove = true;
    public GameObject ItemHolder;

    void Start()
    {
        _robotInv = gameManager.GetComponent<RobotInv>();
        builder = gameManager.GetComponent<BuildSystem>();
        cameraMain = Camera.main;
        player = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray directionClick = cameraMain.ScreenPointToRay(Input.mousePosition);//ray casted from camera prespective
        RaycastHit hitZone;

        hit = Physics.Raycast(directionClick, out hitZone);
        direction = new Vector3(hitZone.point.x, transform.position.y, hitZone.point.z);
        
        if(player.velocity == new Vector3(0,0,0))
        {
            transform.LookAt(direction);
        }
            objectTag = hitZone.collider.tag;

            if (Input.GetMouseButtonDown(0) && !isMouseOnUI() && canMove)
            {
                if (hit)
                {
                    switch (objectTag)
                    {
                        case "Level":
                            player.SetDestination(hitZone.point); //transforms hit into Vector 3
                            break;
                        case "IronRock":
                            if(Vector3.Distance( player.transform.position, hitZone.point) > 3)
                            {
                                player.SetDestination(hitZone.point);
                            }
                            break;
                        case "Chest":
                            if (Vector3.Distance(player.transform.position, hitZone.point) > 1)
                            {
                                player.SetDestination(hitZone.point);
                            }
                            break;
                        case "Robot":
                            {
                                if (Vector3.Distance(player.transform.position, hitZone.point) > 1)
                                {
                                    player.SetDestination(hitZone.point);
                                }
                                break;
                            }
                    }

                    
                }
            }

        /*
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        //plays the animation on movement
        animator.SetFloat("Movement", translation*50f);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);*/
    }
    public bool isMouseOnUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
