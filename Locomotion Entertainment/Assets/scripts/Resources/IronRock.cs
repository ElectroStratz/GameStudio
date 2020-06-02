using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronRock : ResourceObject
{

    [SerializeField]
    private Image hp_ui;

    [SerializeField]
    private Canvas hpHolder;


    // Start is called before the first frame update
    void Start()
    {
        this._particleSys.Pause();
        InvokeRepeating("GrowBack", _refillTime, _refillTime);
    }

    // Update is called once per frame
    void Update()
    {
        hp_ui.fillAmount = _currentResources / _resourceSize;
        if(hp_ui.fillAmount == 1)
        {
            hpHolder.gameObject.SetActive(false);
        }
        else
        {
            hpHolder.gameObject.SetActive(true);
        }
    }



}

