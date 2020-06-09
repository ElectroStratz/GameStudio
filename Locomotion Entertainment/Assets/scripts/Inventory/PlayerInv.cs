using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public List<InventoryItem> inventory;
    [SerializeField]
    public int inventorySize;
    [SerializeField]
    public int maxStack;
    private int emptySlots;
    public GameObject inventoryUI;
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
    
    public void AddToInventory(string item, int amount, Sprite icon)
    {
        bool inInventory = false;
        List<int> positions = new List<int>();
        float remaining = amount;
        float availableAmount = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                inInventory = true;
                positions.Add(i);
            }
        }

        if (inInventory)
        {
            for(int i = 0 ; i < positions.Count ; i++)
            {
                availableAmount = maxStack - inventory[positions[i]].GetAmount();

                if(availableAmount > 0)
                {
                    if(availableAmount >= remaining)
                    {
                        inventory[positions[i]].AddAmount(remaining);
                        remaining = 0;
                        break;
                    }
                    else
                    {
                        inventory[positions[i]].AddAmount(availableAmount);
                        remaining = remaining - availableAmount;
                    }
                }
            }
            
            if(remaining > 0)
            {
                positions.Clear();
                if (emptySlots == 0)
                {
                    //inventory full cant handle more
                    //deal with the remaining that needs to be added
                }
                else
                {
                    for (int i = 0; i < inventorySize; i++)
                    {
                        if (inventory[i].GetName() == "")
                        {
                            positions.Add(i);
                        }
                    }

                    for (int i = 0; i < positions.Count; i++)
                    {
                        availableAmount = maxStack - inventory[positions[i]].GetAmount();

                        if (availableAmount > 0)
                        {
                            if (availableAmount >= remaining)
                            {
                                inventory[positions[i]].AddItem(item, remaining, icon);
                                remaining = 0;
                                emptySlots--;
                                break;
                            }
                            else
                            {
                                inventory[positions[i]].AddItem(item, availableAmount, icon);
                                remaining = remaining - availableAmount;
                                emptySlots--;
                            }
                        }
                    }

                    if(remaining > 0)
                    {
                        //inventory full
                    }

                }
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                if (onItemUpdatedCallback != null)
                {
                    onItemUpdatedCallback.Invoke();
                }
            }
        }
        else
        {
            if (emptySlots == 0)
            {
                //inventory full cant handle more
                //deal with the remaining that needs to be added
            }
            else
            {
                for (int i = 0; i < inventorySize; i++)
                {
                    if (inventory[i].GetName() == "")
                    {
                        positions.Add(i);
                    }
                }

                for (int i = 0; i < positions.Count; i++)
                {
                    availableAmount = maxStack - inventory[positions[i]].GetAmount();

                    if (availableAmount > 0)
                    {
                        if (availableAmount >= remaining)
                        {
                            inventory[positions[i]].AddItem(item, remaining, icon);
                            emptySlots--;
                            remaining = 0;
                            break;
                        }
                        else
                        {
                            inventory[positions[i]].AddItem(item, availableAmount, icon);
                            remaining = remaining - availableAmount;
                            emptySlots--;
                        }
                    }
                }

                if (remaining > 0)
                {
                    //inventory full
                }

            }
            
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            if (onItemUpdatedCallback != null)
            {
                onItemUpdatedCallback.Invoke();
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
                amount += inventory[i].GetAmount();
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

    //needs update
    public bool RemoveFromInventory(string item, float amount)
    {
        bool inInventory = false;
        int itemStatus = 0;
        float remaining = amount;
        float availableAmount = 0;
        List<int> positions = new List<int>();

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                inInventory = true;
                positions.Add(i);
            }
        }
        if (inInventory)
        {
            availableAmount = this.GetItemAmount(item);
            if (availableAmount >= remaining)
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    availableAmount = inventory[positions[i]].GetAmount();
                    if (availableAmount >= remaining)
                    {
                        itemStatus = inventory[positions[i]].RemoveAmount(remaining);
                        remaining = 0;
                        if (itemStatus == 1)
                        {
                            emptySlots++;
                        }
                        break;
                    }
                    else
                    {
                        itemStatus = inventory[positions[i]].RemoveAmount(availableAmount);
                        remaining = remaining - availableAmount;
                        emptySlots++;
                    }
                }
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
            else
            {
                return false;
                //not enough

            }
            
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
            OpenInventory();
        }
        for (int i = 0; i < inventorySize; i++)
        {
            itemNames[i] = inventory[i].GetName();
            itemAmounts[i] = inventory[i].GetAmount();
        }
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        Player_Controller.canMove = !Player_Controller.canMove;
    }
}
