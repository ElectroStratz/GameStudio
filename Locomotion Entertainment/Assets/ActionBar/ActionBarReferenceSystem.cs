using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarReferenceSystem : MonoBehaviour
{
    [SerializeField]
    public int actionbarSize;
    
    public GameObject actionbarPanel;
    public GameObject actionbarSlot;
    
    ActionBarSlotSystem[] actionbarSlots;


    PlayerInv _Playerinventory;

    // Start is called before the first frame update
    void Start()
    {
        _Playerinventory = GetComponent<PlayerInv>();
        _Playerinventory.onItemUpdatedCallback += UpdateUI;
        
        
        //build action bar
        for (int i = 0; i < actionbarSize; i++)
        {
            Instantiate(actionbarSlot, actionbarPanel.transform);
            actionbarSlot.transform.parent = actionbarPanel.transform;
        }

        actionbarSlots = actionbarPanel.GetComponentsInChildren<ActionBarSlotSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        /*for( var i = 0; i < _Playerinventory.inventorySize; i++)
        {
            var tempinvItem = _Playerinventory.inventory[i].GetName();
            print(tempinvItem);
        }*/
    }

    void UpdateUI()
    {
        for (int i = 0; i < _Playerinventory.inventorySize; i++)
        {
            print(_Playerinventory.inventory[i].GetName());
            if (_Playerinventory.inventory[i].GetName() == "food")
            {
                Sprite icon = _Playerinventory.inventory[i].GetIcon();
                actionbarSlots[2].AddItem(icon);
                break;
            }
            else
            {
                actionbarSlots[2].ClearSlot();
            }

        }
    }
}
