using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUISystem : MonoBehaviour
{
    [SerializeField]
    private GameObject chestUI;
    public GameObject _chest;
    private ChestSystem _chestInventory;
    public Transform itemsParent;
    private GameObject[] chestsObjects;
    private bool isReady = false;

    InventorySlotSystem[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitChests());
    }

    IEnumerator WaitChests()
    {
        yield return new WaitUntil(() => isReady == true);
        chestUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            chestsObjects = GameObject.FindGameObjectsWithTag("ChestObject");

            foreach (var chest in chestsObjects)
            {
                if(chest.GetComponent<ChestSystem>().inventory.Count <= 0)
                {
                    isReady = false;
                    break;
                }
                else
                {
                    isReady = true;
                }
            }

            if (isReady)
            {
                chestUI.SetActive(false);
            }
        }

        if(_chest != null)
        {
            _chestInventory = _chest.GetComponent<ChestSystem>();
            _chestInventory.onItemChangedCallback += UpdateUI;
            inventorySlots = itemsParent.GetComponentsInChildren<InventorySlotSystem>();
        }
    }


    

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (_chestInventory.inventory[i].GetAmount() > 0)
            {
                inventorySlots[i].AddItem(_chestInventory.inventory[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }
    }

    public void SetChest(GameObject destination)
    {
        _chest = destination;
    }
}
