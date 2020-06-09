using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform targetPlayer;
    [SerializeField]
    private float distance = 2f;
    NavMeshAgent robotAgent;
    GameObject manager;
    RobotInv _robotInv;
    void Start()
    {
        robotAgent = GetComponent<NavMeshAgent>();
        manager = GameObject.FindGameObjectWithTag("GameManager");
        _robotInv = manager.GetComponent<RobotInv>();
    }

    // Update is called once per frame
    void Update()
    {
        robotAgent.SetDestination(targetPlayer.position);
        robotAgent.stoppingDistance = distance;
    }

    void OnMouseDown()
    {
        _robotInv.OpenInventory();
    }
}
