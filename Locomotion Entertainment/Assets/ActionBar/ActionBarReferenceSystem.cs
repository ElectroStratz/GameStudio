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

    Color selected, normal;
    PlayerInv _Playerinventory;
    // Start is called before the first frame update
    void Start()
    {
        normal = Color.white;
        selected = new Color (00, 0.5986471f, 1, 1);
        _Playerinventory = GetComponent<PlayerInv>();
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
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectedSlot(3);
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
    void UpdateUI()
    {
        for (int i = 0; i < _Playerinventory.inventorySize; i++)
        {

            if (_Playerinventory.inventory[i].GetName() == "Pick Axe")
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
