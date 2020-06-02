﻿using System.Collections;
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
        print(iconItem.name);
    }

    public void AddAmount(float amount)
    {
        this.itemAmount += amount;
    }

    public int RemoveAmount(float amount)
    {
        float result = this.itemAmount - amount;
        if (result < 0)
        {
            return 0;
        }
        else if (result == 0)
        {
            this.itemName = "";
            this.itemAmount = 0;
            this.iconItem = null;
            return 1;
        }
        else
        {
            this.itemAmount = result;
            return 2;
        }

    }
    private void FindIcon()
    {
        //GameObject iconTemp;
        Sprite icon = Resources.Load<Sprite>("Sprites/Pickaxe");
        // iconTemp.GetComponent<Image>().sprite = icon[0];
        //print(icon[0].);
        this.iconItem = icon;
    }
    public string GetName()
    {
        return this.itemName;
    }

    public float GetAmount()
    {
        return this.itemAmount;
    }

    public Sprite GetIcon()
    {
        return this.iconItem;
    }
}
