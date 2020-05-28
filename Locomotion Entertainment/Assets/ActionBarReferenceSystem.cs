using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarReferenceSystem : MonoBehaviour
{
    public Image icon;
    PlayerInv _playerinv;
    InventoryItem item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for( var i = 0; i < _playerinv.inventorySize; i++)
        {
            var tempinvItem = _playerinv.inventory[i].GetName();
            print(tempinvItem);
        }
    }
}
