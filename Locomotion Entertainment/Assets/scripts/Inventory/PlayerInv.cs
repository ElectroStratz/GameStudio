using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public List<InventoryItem> inventory;
    [SerializeField]
    public int inventorySize;
    int emptySlots;
    public GameObject inventoryPanel;
    public GameObject inventorySlot;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public delegate void OnItemUpdated();
    public OnItemUpdated onItemUpdatedCallback;
    private void Awake()
    {

        for (int i = 0; i < inventorySize; i++)
        {
            inventory.Add(new InventoryItem());
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

                inventory[position].AddItem(item, amount, icon);
                emptySlots--;
                if(onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                if (onItemUpdatedCallback != null)
                {
                    onItemUpdatedCallback.Invoke();
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
            if (inventory[i].GetName() == item)
            {
                amount = inventory[i].GetAmount();
                break;
            }
        }
        
        return amount;
    }

    public Sprite GetItemSprite(string item)
    {
        Sprite icon = null;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                icon = inventory[i].GetIcon();
                break;
            }
        }

        return icon;
    }

    public bool RemoveFromInventory(string item, float amount)
    {
        bool inInventory = false;
        int itemStatus = 0;
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
            itemStatus = inventory[position].RemoveAmount(amount);
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
                if (onItemUpdatedCallback != null)
                {
                    onItemUpdatedCallback.Invoke();
                }
                return true;
            case 2: //item still exists in inventory
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                if (onItemUpdatedCallback != null)
                {
                    onItemUpdatedCallback.Invoke();
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
            itemNames[i] = inventory[i].GetName();
            itemAmounts[i] = inventory[i].GetAmount();
        }
    }
}
