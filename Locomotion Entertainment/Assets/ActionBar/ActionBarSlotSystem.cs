using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarSlotSystem : MonoBehaviour
{
    public Image icon;

    ActionBarItem item;
    public void AddItem(Sprite newItem)
    {
       // item = newItem;

        icon.sprite = item.iconItem;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
