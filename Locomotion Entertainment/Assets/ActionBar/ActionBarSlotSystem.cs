using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarSlotSystem : MonoBehaviour
{
    public Image icon;
    
    public void AddItem(Sprite newItem)
    {
        icon.sprite = newItem;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
