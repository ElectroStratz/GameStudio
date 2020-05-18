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

    [SerializeField]
    private float minZoom = 5f;

    [SerializeField]
    private float maxZoom = 15f;

    [SerializeField]
    private float zoomSpeed = 4f;

    void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
    }
    void LateUpdate()
    {
        transform.position = player.position - cameraOffset * zoom;
        transform.LookAt(player.position + Vector3.up * playerHeight);
    }
}
