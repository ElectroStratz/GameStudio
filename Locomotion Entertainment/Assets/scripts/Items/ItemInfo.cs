using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    private int         _id;
    private string      _name; 
    private string      _type;
    private string      _station; 
    private Sprite      _icon;
    private GameObject  _object;
    private string      _tier; 

    public List<ItemComponent> _components; 
    
    public ItemInfo(int id, string itemname, string type, string station, string tier, Sprite icon, GameObject _object)
    {
        _components = new List<ItemComponent>();
        this._id = id;
        this._name = itemname;
        this._type = type;
        this._station = station;
        this._tier = tier;
        this._icon = icon;
        this._object = _object;
    }

    public void AddComponent(string compName, int amount)
    {
        _components.Add(new ItemComponent(compName, amount));
    }

    public Sprite GetIcon()
    {
        return this._icon;
    }

    public string GetName()
    {
        return this._name;
    }

    public string GetStation()
    {
        return this._station;
    }

    public string GetTier()
    {
        return this._tier;
    }
    
    public GameObject GetObject()
    {
        return this._object;
    }
    public List<ItemComponent> GetComponentsList()
    {
        return this._components;
    }
}
