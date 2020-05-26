using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    private string itemName;
    private float itemAmount;
    public Sprite iconItem;

    public InventoryItem ()
    {
        itemName = "";
        itemAmount = 0;
        iconItem = null;
    }

    public void AddItem(string item, float amount, Sprite icon)
    {
        this.itemName = item;
        this.itemAmount = amount;
        this.iconItem = icon;
    }

    public void AddAmount(float amount)
    {
        this.itemAmount += amount;
    }

    public bool RemoveAmount(float amount)
    {
        float result = this.itemAmount - amount;
        if(result < 0)
        {
            return false;
        }
        else if(result == 0)
        {
            this.itemName = "";
            this.itemAmount = 0;
            return true;
        }
        else
        {
            this.itemAmount = result;
            return true;
        }

    }

    public string GetName()
    {
        return this.itemName;
    }

    public float GetAmount()
    {
        return this.itemAmount;
    }
}
