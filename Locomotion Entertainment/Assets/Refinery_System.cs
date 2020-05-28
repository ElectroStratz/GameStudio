using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refinery_System : MonoBehaviour
{
    PlayerInv _Playerinventory;

    public GameObject refineryPanel;
    bool isOpen;
    void Start()
    {
        _Playerinventory = GetComponent<PlayerInv>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            CheckInventory();
        }
    }

    private void OnMouseDown()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            refineryPanel.SetActive(true);
        }
        else
        {
            refineryPanel.SetActive(false);
        }
    }

    private void CheckInventory()
    {
        for (int i = 0; i < _Playerinventory.inventorySize; i++)
        {
            if (_Playerinventory.inventory[i].GetName() == "iron ore")
            {
                print("Yes you have it");
                int position1 = i;
                var ammount1 = _Playerinventory.inventory[i].GetAmount();
                if (_Playerinventory.inventory[i].GetName() == "copper ore")
                { 
                    int position2 = i;
                    var ammount2 = _Playerinventory.inventory[i].GetAmount();
                    if (ammount1 == 1 && ammount2 == 1)
                    {
                        print("You can Craft!");
                        if (Input.GetKeyDown(KeyCode.K))
                        {
                            _Playerinventory.inventory[position1].RemoveAmount(ammount1);
                            _Playerinventory.inventory[position2].RemoveAmount(ammount2);
                        }
                    }
                }
                else
                {
                    print("You Dont Have it");
                }
            }
            else
            {
                print("You Dont Have it");
            }

        }
    }
}
