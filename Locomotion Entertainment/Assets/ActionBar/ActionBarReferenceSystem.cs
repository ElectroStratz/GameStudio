using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarReferenceSystem : MonoBehaviour
{
    public List<ActionBarItem> actionbar;
    public GameObject actionbarPanel;
    public GameObject actionbarSlot;
    public int actionbarSize = 4;
    int emptySlots;
    ActionBarSlotSystem[] actionbarSlots;


    PlayerInv _Playerinventory;
    InventoryItem item;
    InventorySlotSystem[] inventorySlots;

    // Start is called before the first frame update
    void Start()
    {
        _Playerinventory = GetComponent<PlayerInv>();
        inventorySlots = actionbarPanel.GetComponentsInChildren<InventorySlotSystem>();
        _Playerinventory.onItemChangedCallback += UpdateUI;

        for (int i = 0; i < actionbarSize; i++)
        {
            actionbar.Add(new ActionBarItem());
            Instantiate(actionbarSlot, actionbarPanel.transform);
            actionbarSlot.transform.parent = actionbarPanel.transform;
        }
        emptySlots = actionbarSize;
    }

    // Update is called once per frame
    void Update()
    {
        for( var i = 0; i < _Playerinventory.inventorySize; i++)
        {
            var tempinvItem = _Playerinventory.inventory[i].GetName();
            print(tempinvItem);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (_Playerinventory.inventory[i].GetName() == "food")
            {
                inventorySlots[i].AddItem(_Playerinventory.inventory[i]);
                Sprite tempIcon = _Playerinventory.inventory[i].GetComponentInChildren<Sprite>();
               // actionbarSlots[i].AddItem(actionbar.tempIcon);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }
    }
}
