using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    protected GameObject _manager;
    protected GameObject _player;
    protected PlayerInv _inventory;
    [Header("Default Settings")]
    [SerializeField]
    protected string _resourceName;
    [SerializeField]
    protected Sprite _icon;
    [SerializeField]
    protected float _resourceAmmount;
    [SerializeField]
    protected bool _craftItem;
    [SerializeField]
    protected bool _equipableItem;
    [Header("Optional Settings")]
    [SerializeField]
    protected int _levelItem;
    [SerializeField]
    protected GameObject _objectItem;


    public bool equippedItem;
    public Vector3 rotationItem;
    // Start is called before the first frame update
    void Start()
    {
        if (_equipableItem)
        {
            _craftItem = false;
            _objectItem = GetComponent<GameObject>();
        }
        else
        {
            _craftItem = true;
            _equipableItem = false;
        }
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
