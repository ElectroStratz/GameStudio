using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ItemList : MonoBehaviour
{
    [SerializeField]
    public TextAsset _textFile;
    public List<Sprite> _sprites;
    public List<GameObject> _objects;
    public List<ItemInfo> _items;


    public List<ItemComponent> _componentList;

    public string[] _lines;
    public string[] _itemName;
    public string[] _itemComponents;
    public string[] _itemStation;
    public string[] _itemTier;
    public string _itemType;

    public string[] _components;
    public string[] _componentSplit;

    private int _id = 0;
    private StartingItems _startItem;

    // Start is called before the first frame update
    void Start()
    {
        _items = new List<ItemInfo>();
        _startItem = GetComponent<StartingItems>();
        _componentList = new List<ItemComponent>();
        ReadTextFile();
        _startItem.StartItems();
    }

    private void ReadTextFile()
    {
        _lines = _textFile.text.Split('\n');

        for(int k = 0; k<_lines.Length;k++)
        {
            string line = _lines[k];
           _itemName = line.Split('=');
            _itemComponents = _itemName[1].Split('/');
            _itemStation = _itemComponents[1].Split(',');
            _itemTier = _itemStation[1].Split('-');
            _itemType = _itemTier[1];

            _components = _itemComponents[0].Split('+');

            
            if (_itemName[0] != "")
            {
                if (_itemType.Trim().Equals("Material"))
                {
                    Sprite icon = FindIcon(_itemName[0]);
                    _items.Add(new ItemInfo(_id, _itemName[0], _itemType, _itemStation[0], _itemTier[0], icon, null));
                }
                else
                {
                    Sprite icon = FindIcon(_itemName[0]);

                    GameObject _object = FindObject(_itemName[0]);

                    _items.Add(new ItemInfo(_id, _itemName[0], _itemType, _itemStation[0], _itemTier[0], icon, _object));
                }
                
                if (_itemComponents[0] != "")
                {
                    for (int i = 0; i < _components.Length; i++)
                    {
                        _componentSplit = _components[i].Split('X');
                        int amount = int.Parse(_componentSplit[0].Trim());
                        _items[_id].AddComponent(_componentSplit[1], amount);
                    }
                }
                
                _id++;
                _componentList.Clear();
            }
        }
    }
    

    private Sprite FindIcon(string name)
    {
        Sprite icon = null;

        foreach (Sprite sprite in _sprites)
        {
            if(sprite.name == name)
            {
                icon = Instantiate(sprite);
                break;
            }
        }
        return icon;
    }

    private GameObject FindObject(string name)
    {
        GameObject objects = null;
        foreach (GameObject objectref in _objects)
        {
            if (objectref.name == name)
            {
                objects = Instantiate(objectref);
                break;
            }
        }
        return objects;
    }

    public Sprite GetIcon(string name)
    {
        Sprite icon = null;
        foreach(ItemInfo item in _items)
        {
            if(item.GetName() == name)
            {
                icon = item.GetIcon();
            }
        }

        return icon;
    }

    public List<ItemInfo> GetList()
    {
        return this._items;
    }
}
