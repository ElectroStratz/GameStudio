using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBarItem : MonoBehaviour
{
    private string itemName;
    public Sprite iconItem;

    public ActionBarItem()
    {
        itemName = "";
        iconItem = null;
    }
    public void AddItem(string item, Sprite icon)
    {
        this.itemName = item;
        this.iconItem = icon;
    }

    public void RemoveItem()
    {
        this.itemName = "";
        this.iconItem = null;
    }

    public string GetName()
    {
        return this.itemName;
    }

    public Sprite GetIcon()
    {
        return this.iconItem;
    }
}
