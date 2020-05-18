using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Controller : MonoBehaviour
{
    Camera cameraMain;
    NavMeshAgent player;
    Vector3 point;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray directionClick = cameraMain.ScreenPointToRay(Input.mousePosition);//ray casted from camera prespective
            RaycastHit hit;

            if(Physics.Raycast(directionClick, out hit))
            {
                player.SetDestination(hit.point); //transforms hit into Vector 3
            }
        }
    }
}
