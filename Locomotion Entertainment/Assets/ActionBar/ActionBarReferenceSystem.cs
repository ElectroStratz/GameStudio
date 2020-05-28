using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarReferenceSystem : MonoBehaviour
{
    public List<ActionBarItem> actionbar;
    public Image icon;
    float amount;
    public GameObject actionbarPanel;
    public GameObject actionbarSlot;
    public int actionbarSize = 4;
    int emptySlots;
    ActionBarItem actiomItem;
    ActionBarSlotSystem[] actionbarSlots;


    PlayerInv _playerinv;
    InventoryItem item;
    InventorySlotSystem[] inventorySlots;

    // Start is called before the first frame update
    void Start()
    {
        _playerinv = GetComponent<PlayerInv>();
        inventorySlots = actionbarPanel.GetComponentsInChildren<InventorySlotSystem>();
        _playerinv.onItemChangedCallback += UpdateUI;

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
        for( var i = 0; i < _playerinv.inventorySize; i++)
        {
            var tempinvItem = _playerinv.inventory[i].GetName();
            print(tempinvItem);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (_playerinv.inventory[i].GetName() == "food")
            {
            }
            else
            {
                actionbarSlots[i].ClearSlot();
            }

        }
    }
}
