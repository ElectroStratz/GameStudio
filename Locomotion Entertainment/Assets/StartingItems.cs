using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingItems : MonoBehaviour
{
    ItemList _items;
    PlayerInv _Playerinventory;
    // Start is called before the first frame update
    void Start()
    {
        _items = GetComponent < ItemList >();
        _Playerinventory = GetComponent<PlayerInv>();
        StartItems();

    }
    public void StartItems()
    {
        _Playerinventory.AddToInventory("Pickaxe", 1, _items.getIcon("Pickaxe.png"));
        _Playerinventory.AddToInventory("Shovel", 1, null);
    }

}
