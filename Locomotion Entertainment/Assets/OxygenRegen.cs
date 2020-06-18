using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRegen : MonoBehaviour
{
    [SerializeField]
    private float radius = 5f;
    GameObject _player;

    Player_Attributes _playerAttributes;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerAttributes = _player.GetComponent<Player_Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
       var distance = Vector3.Distance(_player.transform.position, gameObject.transform.position);
        if (distance <= radius )
        {
            InvokeRepeating("OxygenRefill", 1, 10);
        }
    }

    void OxygenRefill()
    {
        if(_playerAttributes.currentOxygen < 100)
        {
            _playerAttributes.currentOxygen += 10;
        }
    }
}
