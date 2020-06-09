using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    public string compname;
    public int amount;

    public ItemComponent(string name, int amount)
    {
        this.compname = name;
        this.amount = amount;
    }
    
}
