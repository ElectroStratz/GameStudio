using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingItems : MonoBehaviour
{
    PlayerInv _Playerinventory;
    // Start is called before the first frame update
    void Start()
    {
        _Playerinventory = GetComponent<PlayerInv>();
        StartItems();

    }
    public void StartItems()
    {
        _Playerinventory.AddToInventory("PickAxe", 1, null);
        _Playerinventory.AddToInventory("Shovel", 1, null);
    }

}
