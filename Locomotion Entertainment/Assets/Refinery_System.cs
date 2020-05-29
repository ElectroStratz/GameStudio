using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refinery_System : MonoBehaviour
{
    PlayerInv _Playerinventory;

    public GameObject refineryPanel;
    private GameObject player;
    bool isOpen;
    bool isCraftable;
    void Start()
    {
        _Playerinventory = GetComponent<PlayerInv>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        if(Vector3.Distance(this.transform.position, player.transform.position) < 3)
        {
            if (isOpen)
            {
                refineryPanel.SetActive(true);
            }
            else
            {
                refineryPanel.SetActive(false);
            }
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
                        isCraftable = true;
                        CraftItem(ammount1, ammount2, position1, position2);
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

    private void CraftItem(float ammount1, float ammount2, int position1, int position2)
    {
        if (isCraftable)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _Playerinventory.inventory[position1].RemoveAmount(ammount1);
                _Playerinventory.inventory[position2].RemoveAmount(ammount2);
                _Playerinventory.AddToInventory("new item", 1 , null);
            }
        }

    }
}
