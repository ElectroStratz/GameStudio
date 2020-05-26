using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public List<InventoryItem> inventoryItem;
    [SerializeField]
    int inventorySize;
    int emptySlots;
    public GameObject inventoryPanel;
    public GameObject inventorySlot;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {

        for (int i = 0; i < inventorySize; i++)
        {
            inventoryItem.Add(new InventoryItem());
            Instantiate(inventorySlot, inventoryPanel.transform);
            inventorySlot.transform.parent = inventoryPanel.transform;
        }
        emptySlots = inventorySize;

        //for debugging
        for (int i = 0; i < inventorySize; i++)
        {
            itemNames.Add("");
            itemAmounts.Add(0);
        }
    }
    
    public void AddToInventory(string item, float amount, Sprite icon)
    {
        bool inInventory = false;
        int position = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItem[i].GetName() == item)
            {
                inInventory = true;
                position = i;
                break;
            }
        }

        if (inInventory)
        {
            inventoryItem[position].AddAmount(amount);
        }
        else
        {
            if (emptySlots != 0)
            {
                for (int i = 0; i < inventorySize; i++)
                {
                    if (inventoryItem[i].GetName() == "")
                    {
                        position = i;
                        break;
                    }
                }

                inventoryItem[position].AddItem(item, amount, icon);
                emptySlots--;
                if(onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }

            }
            else
            {
                //Inventory Full
            }
        }
    }

    public float GetItemAmount(string item)
    {
        float amount = 0;
        
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItem[i].GetName() == item)
            {
                amount = inventoryItem[i].GetAmount();
                break;
            }
        }
        
        return amount;
    }

    public bool RemoveFromInventory(string item, float amount)
    {
        bool inInventory = false;
        int itemStatus = 0;
        int position = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItem[i].GetName() == item)
            {
                inInventory = true;
                position = i;
                break;
            }
        }
        if (inInventory)
        {
            itemStatus = inventoryItem[position].RemoveAmount(amount);
        }

        switch (itemStatus)
        {
            case 0: //not enough quantity
                return false;
            case 1: //item was removed from inventory
                emptySlots++;
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            case 2: //item still exists in inventory
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
        }

        return false;
    }

    //for debugging

    public List<string> itemNames;
    public List<float> itemAmounts;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
        for (int i = 0; i < inventorySize; i++)
        {
            itemNames[i] = inventoryItem[i].GetName();
            itemAmounts[i] = inventoryItem[i].GetAmount();
        }
    }
}
