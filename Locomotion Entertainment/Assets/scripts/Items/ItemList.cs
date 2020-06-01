using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ItemList : MonoBehaviour
{
    [SerializeField]
    public TextAsset _textFile;
    public List<ItemInfo> _items;


    public List<(string, int)> _componentList;

    public string[] _lines;
    public string[] _itemName;
    public string[] _itemComponents;
    public string[] _itemStation;
    public string[] _itemTier;
    public string   _itemType;

    public string[] _components;
    public string[] _componentSplit;

    private int _id;
    
    // Start is called before the first frame update
    void Start()
    {
        _items = new List<ItemInfo>();
        _componentList = new List<(string, int)>();
        ReadTextFile();
    }

    private void ReadTextFile()
    {
        _lines = _textFile.text.Split('\n');

        foreach(string line in _lines)
        {
            _itemName = line.Split('=');
            _itemComponents = _itemName[1].Split('/');
            _itemStation = _itemComponents[1].Split(',');
            _itemTier = _itemStation[1].Split('-');
            _itemType = _itemTier[1];

            _components = _itemComponents[0].Split('+');
            for(int i = 0; i < _components.Length; i++)
            {
                _componentSplit = _components[i].Split('x');
                int amount = int.Parse(_componentSplit[0]);
                _componentList.Add((_componentSplit[1],amount));
            }

            if(_itemName[0] != "")
            {
                if(_itemType == "Material")
                {
                    Sprite icon = getIcon();

                    _items.Add(new ItemInfo(_id, _itemName[0], _itemType, _itemStation[0], _itemTier[0], icon, null, _componentList));
                }
                else
                {
                    Sprite _icon = getIcon();

                    GameObject _object = getObject(); 

                    _items.Add(new ItemInfo(_id, _itemName[0], _itemType, _itemStation[0], _itemTier[0], _icon, _object, _componentList));
                }
                

                _id++;
                _componentList.Clear();
            }
        }
        
    }

    private Sprite getIcon()
    {
        Sprite icon = null;

        icon = Resources.Load<Sprite>("Pickaxe");
        return icon;
    }

    private GameObject getObject()
    {
        GameObject _object = null;

        return _object;
    }

    public Sprite getIcon(string name)
    {
        Sprite icon = null;

        foreach(ItemInfo item in _items)
        {
            if(item.GetName() == name)
            {
                icon = item.GetIcon();
                break;
            }
        }

        return icon;
    }
}
