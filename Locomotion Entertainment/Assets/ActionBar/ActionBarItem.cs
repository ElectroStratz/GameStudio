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
    public void AddItemActionBar(string item, Sprite icon)
    {
        this.itemName = item;
        this.iconItem = icon;
    }

    public int RemoveItemIcon(Sprite icon)
    {
        Sprite result = icon;
        if (result == null)
        {
            this.itemName = "";
            this.iconItem = null;
            return 1;
        }
        else
        {
            this.iconItem = result;
            return 2;
        }

    }

    public string GetName()
    {
        return this.itemName;
    }
}
