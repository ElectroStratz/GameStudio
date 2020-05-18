using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private float playerHeight = 2f;

    private float zoom = 10f;
    void LateUpdate()
    {
        transform.position = player.position - cameraOffset * zoom;
        transform.LookAt(player.position + Vector3.up * playerHeight);
    }
}
