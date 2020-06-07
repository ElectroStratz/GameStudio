using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    public string name;
    public int amount;

    public ItemComponent(string name, int amount)
    {
        this.name = name;
        this.amount = amount;
    }
}
