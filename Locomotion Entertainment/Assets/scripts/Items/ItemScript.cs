using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    protected GameObject _manager;
    protected GameObject _player;
    protected PlayerInv _inventory;
    [Header("Default Settings")]
    public bool equippedItem;
    public Vector3 rotationItem;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (equippedItem)
        {
            gameObject.transform.localEulerAngles = rotationItem;
        }

    }
}
