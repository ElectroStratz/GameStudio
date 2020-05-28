using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarReferenceSystem : MonoBehaviour
{
    public Image icon;
    PlayerInv _playerinv;
    InventoryItem item;

    InventorySlotSystem[] inventorySlots;
    public Transform actionPanel;

    // Start is called before the first frame update
    void Start()
    {
        _playerinv = GetComponent<PlayerInv>();
        inventorySlots = actionPanel.GetComponentsInChildren<InventorySlotSystem>();
        _playerinv.onItemChangedCallback += UpdateUI;
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
        for (int i = 0; i < 4; i++)
        {
            if (_playerinv.inventory[i].GetAmount() > 0)
            {
                inventorySlots[i].AddItem(_playerinv.inventory[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }
        print(inventorySlots.ToString());
    }
}
