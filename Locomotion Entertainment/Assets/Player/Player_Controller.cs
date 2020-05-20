using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Controller : MonoBehaviour
{
    Camera cameraMain;
    NavMeshAgent player;
    Vector3 direction;
    Animator animator;
    public GameObject gameManager;
    private BuildSystem builder;

    private float speed = 3.5f;
    private float rotationSpeed = 100.0f;
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
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

       if (builder.GetIsBuilding() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit)
                {
                    player.SetDestination(hitZone.point); //transforms hit into Vector 3
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
}
