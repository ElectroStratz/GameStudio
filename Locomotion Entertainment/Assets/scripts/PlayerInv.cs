using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public List<InventoryItem> inventory;
    int inventorySize;
    int emptySlots;

    private void Awake()
    {
        inventorySize = 10;

        for (int i = 0; i < inventorySize; i++)
        {
            inventory.Add(new InventoryItem());
        }
        emptySlots = inventorySize;

        //for debugging
        for (int i = 0; i < inventorySize; i++)
        {
            itemNames.Add("");
            itemAmounts.Add(0);
        }
    }
    
    public void AddToInventory(string item, float amount)
    {
        bool inInventory = false;
        int position = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                inInventory = true;
                position = i;
                break;
            }
        }

        if (inInventory)
        {
            inventory[position].AddAmount(amount);
        }
        else
        {
            if (emptySlots != 0)
            {
                for (int i = 0; i < inventorySize; i++)
                {
                    if (inventory[i].GetName() == "")
                    {
                        position = i;
                        break;
                    }
                }

                inventory[position].AddItem(item, amount);
                emptySlots--;
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
            if (inventory[i].GetName() == item)
            {
                amount = inventory[i].GetAmount();
                break;
            }
        }
        
        return amount;
    }

    public bool RemoveFromInventory(string item, float amount)
    {
        bool inInventory = false;
        bool possible = false;
        int position = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                inInventory = true;
                position = i;
                break;
            }
        }
        if (inInventory)
        {
            possible = inventory[position].RemoveAmount(amount);
        }

        return possible;
    }

    //for debugging

    public List<string> itemNames;
    public List<float> itemAmounts;
    private void Update()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            itemNames[i] = inventory[i].GetName();
            itemAmounts[i] = inventory[i].GetAmount();
        }
    }
}
