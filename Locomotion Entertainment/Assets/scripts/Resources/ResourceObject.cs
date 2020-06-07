using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    //world information
    protected GameObject _manager;
    protected GameObject _player;
    protected PlayerInv _inventory;

    //resource information
    [SerializeField]
    protected string _resourceName;
    [SerializeField]
    protected Sprite _icon;
    [SerializeField]
    protected int _resourceAmount;
    [SerializeField]
    protected float _resourceSize;
    [SerializeField]
    protected float _refillTime;

    //internal values
    protected float _currentResources;
    protected bool isDepleted;
    protected ParticleSystem _particleSys;


    private void Awake()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = _manager.GetComponent<PlayerInv>();
        _particleSys = GetComponent<ParticleSystem>();

        _currentResources = _resourceSize;
        isDepleted = false;
    }

    public void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 3)
        {
            if (!isDepleted && _currentResources > 0)
            {
                _particleSys.Play();
                _inventory.AddToInventory(_resourceName, _resourceAmount, _icon);
                _currentResources--;
                this.transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
                if (_currentResources == 0)
                {
                    isDepleted = true;
                }
            }

        }

    }

    protected void GrowBack()
    {
        if (isDepleted)
        {
            this.transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y + 0.05f, transform.localScale.z + 0.05f);
            _currentResources++;
            if (_currentResources == _resourceSize)
            {
                isDepleted = false;
            }
        }

    }
}