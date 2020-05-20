using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_AnimatorController : MonoBehaviour
{
    const float animationSmooth = .1f;
    NavMeshAgent player;
    Animator animator;
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercent = player.velocity.magnitude / player.speed;
        animator.SetFloat("Speed", speedPercent, animationSmooth, Time.deltaTime);
    }
}
