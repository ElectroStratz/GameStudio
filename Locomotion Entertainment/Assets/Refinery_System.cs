using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refinery_System : MonoBehaviour
{
    PlayerInv _Playerinventory;
    Camera cameraMain;
    public GameObject refineryPanel;
    bool isOpen = false;
    RaycastHit hitZone;

    void Start()
    {
        cameraMain = Camera.main;
        _Playerinventory = GetComponent<PlayerInv>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckRefineryLocation()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);//ray casted from camera prespective
        Physics.Raycast(ray, out hitZone);
        if (hitZone.collider.tag == "Refinery")
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
    }
    public void CraftItem()
    {
        Sprite icon1 = _Playerinventory.GetItemSprite("Iron");
        Sprite icon2 = _Playerinventory.GetItemSprite("Copper");
        bool component1 = _Playerinventory.RemoveFromInventory("Iron",1);
        bool component2 = _Playerinventory.RemoveFromInventory("Copper", 1);

        if (!component1 && component2)
        {
            _Playerinventory.AddToInventory("Copper", 1, icon2);
        }
        if (!component2 && component1)
        {
            _Playerinventory.AddToInventory("Iron", 1, icon1);
        }
        if (component1 && component2)
        {
            _Playerinventory.AddToInventory("new item", 1, null);
        }
    }
}
