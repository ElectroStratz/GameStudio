using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public GameObject sun, moon;

    [SerializeField]
    private float daySpeed = 0.2f;

    void Update()
    {
        sun.transform.RotateAround(Vector3.zero, Vector3.right, daySpeed * Time.deltaTime);
        moon.transform.RotateAround(Vector3.zero, Vector3.right, daySpeed * Time.deltaTime);
    }


}
