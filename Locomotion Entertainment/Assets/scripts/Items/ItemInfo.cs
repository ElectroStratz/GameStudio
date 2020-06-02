﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    private int         _id;
    private string      _name; //
    private string      _type;
    private string      _station; //
    private Sprite      _icon;
    private GameObject  _object;
    private string      _tier; //

    private List<(string, int)> _components; //
    
    public ItemInfo(int id, string name, string type, string station, string tier,  GameObject _object, List<(string, int)> components)
    {
        this._id = id;
        this._name = name;
        this._type = type;
        this._station = station;
        this._tier = tier;
        //this._icon = icon;
        this._object = _object;
        this._components = components;
    }

    public Sprite GetIcon()
    {
        return this._icon;
    }

    public string GetName()
    {
        return this._name;
    }
}
