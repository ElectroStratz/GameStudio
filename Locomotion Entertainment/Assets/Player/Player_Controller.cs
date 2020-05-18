﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Controller : MonoBehaviour
{
    Camera cameraMain;
    NavMeshAgent player;
    Vector3 point;
    Animator animator;

    public float speed = 3.5f;
    public float rotationSpeed = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
        player = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray directionClick = cameraMain.ScreenPointToRay(Input.mousePosition);//ray casted from camera prespective
            RaycastHit hit;

            if(Physics.Raycast(directionClick, out hit))
            {
                player.SetDestination(hit.point); //transforms hit into Vector 3
            }
        }*/
        
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        //plays the animation on movement
        animator.SetFloat("Movement", translation*50f);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
    }
}
