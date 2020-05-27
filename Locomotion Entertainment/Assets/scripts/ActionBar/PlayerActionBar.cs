using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionBar : MonoBehaviour
{
    public List<ActionBarItem> actionbarItem;
    [SerializeField]
    int actionbarSize;
    int emptySlots;
    public GameObject actionbarPanel;
    public GameObject actionbarSlot;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        for (int i = 0; i < actionbarSize; i++)
        {
            actionbarItem.Add(new ActionBarItem());
            Instantiate(actionbarSlot, actionbarPanel.transform);
            actionbarSlot.transform.parent = actionbarPanel.transform;
        }
        emptySlots = actionbarSize;

        //for debugging
        for (int i = 0; i < actionbarSize; i++)
        {
            itemNames.Add("");
            itemAmounts.Add(0);
        }
    }

    public void AddToActionBar(string item, float amount, Sprite icon)
    {
        bool inActionBar = false;
        int position = 0;

        for (int i = 0; i < actionbarSize; i++)
        {
            if (actionbarItem[i].GetName() == item)
            {
                inActionBar = true;
                position = i;
                break;
            }
        }

        if (inActionBar)
        {
            actionbarItem[position].AddAmount(amount);
        }
        else
        {
            if (emptySlots != 0)
            {
                for (int i = 0; i < actionbarSize; i++)
                {
                    if (actionbarItem[i].GetName() == "")
                    {
                        position = i;
                        break;
                    }
                }

                actionbarItem[position].AddItem(item, amount, icon);
                emptySlots--;
                if (onItemChangedCallback != null)
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

        for (int i = 0; i < actionbarSize; i++)
        {
            if (actionbarItem[i].GetName() == item)
            {
                amount = actionbarItem[i].GetAmount();
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

        for (int i = 0; i < actionbarSize; i++)
        {
            if (actionbarItem[i].GetName() == item)
            {
                inInventory = true;
                position = i;
                break;
            }
        }
        if (inInventory)
        {
            itemStatus = actionbarItem[position].RemoveAmount(amount);
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
        for (int i = 0; i < actionbarSize; i++)
        {
            itemNames[i] = actionbarItem[i].GetName();
            itemAmounts[i] = actionbarItem[i].GetAmount();
        }
    }
}
