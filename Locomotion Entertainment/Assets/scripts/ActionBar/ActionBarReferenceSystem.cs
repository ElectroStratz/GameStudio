using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarReferenceSystem : MonoBehaviour
{
    [SerializeField]
    public int actionbarSize;
    
    public GameObject actionbarPanel;
    public GameObject actionbarSlot;
    
    ActionBarSlotSystem[] actionbarSlots;
   
    Player_Controller _playerController;
    GameObject itemObject, previousObject;
    Color selected, normal;

    PlayerInv _Playerinventory;
    ItemList _itemList;
    GameObject _player;
    GameObject _manager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _playerController = _player.GetComponent<Player_Controller>();
        _itemList = _manager.GetComponent<ItemList>();
        _Playerinventory = GetComponent<PlayerInv>();
        normal = Color.white;
        selected = new Color (00, 0.5986471f, 1, 1);
        _Playerinventory.onItemUpdatedCallback += UpdateUI;
        
        
        //build action bar
        for (int i = 0; i < actionbarSize; i++)
        {
            Instantiate(actionbarSlot, actionbarPanel.transform);
            actionbarSlot.transform.parent = actionbarPanel.transform;
        }

        actionbarSlots = actionbarPanel.GetComponentsInChildren<ActionBarSlotSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedSlot(0);
            SelectedObject(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedSlot(1);
            SelectedObject(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedSlot(2);
            SelectedObject(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectedSlot(3);
            SelectedObject(3);
        }
    }
     void SelectedSlot(int i)
    {
        Button buttontemp;
        ColorBlock buttoncolortemp;
        for (int j = 0; j < actionbarSize; j++)
        {
            buttontemp = actionbarSlots[j].GetComponent<Button>();
            buttoncolortemp = actionbarSlots[j].GetComponent<Button>().colors;
            buttoncolortemp.normalColor = normal;
            buttontemp.colors = buttoncolortemp;
        }
        buttontemp = actionbarSlots[i].GetComponent<Button>();
        buttoncolortemp = actionbarSlots[i].GetComponent<Button>().colors;
        buttoncolortemp.normalColor = selected;
        buttontemp.colors = buttoncolortemp;
    }
    void SelectedObject(int keypressed)
    {
        var items = new List<ItemInfo>(_itemList._items);
        if (keypressed == 0)
        {
            foreach (Transform child in _playerController.ItemHolder.transform)
            {
                child.gameObject.SetActive(false);
            }
            for (int k = 0; k < _Playerinventory.inventorySize; k++)
            {
                if (_Playerinventory.inventory[k].GetName() == "Pickaxe")
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].GetName() == "Pickaxe")
                        {
                            itemObject = items[i].GetObject();
                            itemObject.GetComponent<ItemScript>().equippedItem = true;
                            itemObject.transform.parent = _playerController.ItemHolder.transform;
                            itemObject.transform.position = _playerController.ItemHolder.transform.position;
                            itemObject.SetActive(true);
                            break;
                        }
                    }
                    break;
                }
            }
        }
        if(keypressed == 1)
        {
            foreach (Transform child in _playerController.ItemHolder.transform)
            {
                child.gameObject.SetActive(false);
            }
            for (int k = 0; k < _Playerinventory.inventorySize; k++)
            {
                if (_Playerinventory.inventory[k].GetName() == "Shovel")
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].GetName() == "Shovel")
                        {
                            itemObject = items[i].GetObject();
                            itemObject.GetComponent<ItemScript>().equippedItem = true;
                            itemObject.transform.parent = _playerController.ItemHolder.transform;
                            itemObject.transform.position = _playerController.ItemHolder.transform.position;
                            itemObject.SetActive(true);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
    void UpdateUI()
    {
        for (int i = 0; i < _Playerinventory.inventorySize; i++)
        {

            if (_Playerinventory.inventory[i].GetName() == "Pickaxe")
            {
                Sprite icon = _Playerinventory.inventory[i].GetIcon();
                actionbarSlots[0].AddItem(icon);
                break;
            }
            else
            {
                actionbarSlots[0].ClearSlot();
            }
            if (_Playerinventory.inventory[i].GetName() == "Shovel")
            {
                Sprite icon = _Playerinventory.inventory[i].GetIcon();
                actionbarSlots[1].AddItem(icon);
                break;
            }
            else
            {
                actionbarSlots[1].ClearSlot();
            }
            if (_Playerinventory.inventory[i].GetName() == "food")
            {
                Sprite icon = _Playerinventory.inventory[i].GetIcon();
                actionbarSlots[2].AddItem(icon);
                break;
            }
            else
            {
                actionbarSlots[0].ClearSlot();
            }
        }
    }
}
