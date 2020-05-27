using UnityEngine;
using UnityEngine.UI;

public class InventorySlotSystem : MonoBehaviour
{

    public Image icon;

    InventoryItem item;
    public void AddItem (InventoryItem newItem)
    {
        item = newItem;

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
