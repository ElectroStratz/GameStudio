using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingItems : MonoBehaviour
{
    [SerializeField]
    ItemList _items;
    PlayerInv _Playerinventory;

    private void Awake()
    {
        _items = GetComponent<ItemList>();
        _Playerinventory = GetComponent<PlayerInv>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //StartItems();

    }
    public void StartItems()
    {
        Sprite icon = _items.GetIcon("Pickaxe");
        Sprite icon2 = _items.GetIcon("Shovel");
        _Playerinventory.AddToInventory("Pickaxe", 1, icon);
        _Playerinventory.AddToInventory("Shovel", 1, icon2);
    }

}
