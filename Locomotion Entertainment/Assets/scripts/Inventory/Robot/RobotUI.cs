using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotUI : MonoBehaviour
{
    private GameObject _manager;
    private RobotInv _robotInv;
    public Transform itemsParent;

    InventorySlotSystem[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _robotInv = _manager.GetComponent<RobotInv>();
        _robotInv.onItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlotSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (_robotInv.inventory[i].GetAmount() > 0)
            {
                inventorySlots[i].AddItem(_robotInv.inventory[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }
    }
}
