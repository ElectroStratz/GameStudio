using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSystem : MonoBehaviour
{
    private GameObject player;
    private List<GameObject> slots;
    public bool isOpen;

    [SerializeField]
    private GameObject chestUI;
    public GameObject chestPanel;
    public GameObject inventorySlot;
    [SerializeField]
    public int inventorySize;
    [SerializeField]
    public int maxStack;
    private int emptySlots;

    public List<InventoryItem> inventory;
    protected PlayerInv _Playerinventory;
    protected GameObject _manager;
    public string _selectedItem;


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public List<string> itemNames;
    public List<float> itemAmounts;

    private ChestUISystem _chestUiSystem;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<GameObject>();
        inventory = new List<InventoryItem>();
        player = GameObject.FindGameObjectWithTag("Player");
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _chestUiSystem = _manager.GetComponent<ChestUISystem>();
        chestUI = GameObject.FindGameObjectWithTag("Chest");
        chestPanel = GameObject.FindGameObjectWithTag("ChestPanel");
        _Playerinventory = _manager.GetComponent<PlayerInv>();
        emptySlots = inventorySize;
        
        
        //for debugging
        for (int i = 0; i < inventorySize; i++)
        {
            itemNames.Add("");
            itemAmounts.Add(0);
        }
        for (int i = 0; i < inventorySize; i++)
        {
            inventory.Add(new InventoryItem());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            itemNames[i] = inventory[i].GetName();
            itemAmounts[i] = inventory[i].GetAmount();
        }
    }

    private void OnMouseDown()
    {
        isOpen = !isOpen;
        if (Vector3.Distance(this.transform.position, player.transform.position) < 3)
        {
            if (isOpen)
            {
                chestUI.SetActive(true);
                CreateSlots();
                _Playerinventory.inventoryUI.SetActive(true);
                _Playerinventory.setDestInv(gameObject);
                _chestUiSystem.SetChest(gameObject);
                _Playerinventory.isOpen = true;
            }
            else
            {
                isOpen = false;
                DestroySlots();
                chestUI.SetActive(false);
                _Playerinventory.inventoryUI.SetActive(false);
                _Playerinventory.setDestInv(null);
                _chestUiSystem.SetChest(null);
                _Playerinventory.isOpen = false;
            }
            if(chestUI.activeSelf == false)
            {
                isOpen = false;
                DestroySlots();
                _Playerinventory.inventoryUI.SetActive(false);
                _Playerinventory.setDestInv(null);
                _chestUiSystem.SetChest(null);
                _Playerinventory.isOpen = false;
            }

        }
    }

    
    private void CreateSlots()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            var slot = Instantiate(inventorySlot, chestPanel.transform);
            slot.transform.parent = chestPanel.transform;
            Button buttonEvent = slot.GetComponent<Button>();
            InventorySlotSystem invItem = slot.GetComponent<InventorySlotSystem>();
            invItem.ClearSlot();
            buttonEvent.onClick.AddListener(() =>
            {
                try
                {
                    _Playerinventory.SelectedItem(invItem.item.GetName());
                }
                catch (System.Exception e)
                {
                    _Playerinventory.SelectedItem(""); ;
                }
            }
            );
            FillSlots(i, invItem);
            slots.Add(slot);
        }

    }

    private void DestroySlots()
    {
        foreach(var slot in slots)
        {
            Destroy(slot);
        }

        slots.Clear();
    }

    public void AddToInventory(string item, int amount, Sprite icon)
    {
        bool inInventory = false;
        List<int> positions = new List<int>();
        float remaining = amount;
        float availableAmount = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                inInventory = true;
                positions.Add(i);
            }
        }

        if (inInventory)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                availableAmount = maxStack - inventory[positions[i]].GetAmount();

                if (availableAmount > 0)
                {
                    if (availableAmount >= remaining)
                    {
                        inventory[positions[i]].AddAmount(remaining);
                        remaining = 0;
                        break;
                    }
                    else
                    {
                        inventory[positions[i]].AddAmount(availableAmount);
                        remaining = remaining - availableAmount;
                    }
                }
            }

            if (remaining > 0)
            {
                positions.Clear();
                if (emptySlots == 0)
                {
                    //inventory full cant handle more
                    //deal with the remaining that needs to be added
                }
                else
                {
                    for (int i = 0; i < inventorySize; i++)
                    {
                        if (inventory[i].GetName() == "")
                        {
                            positions.Add(i);
                        }
                    }

                    for (int i = 0; i < positions.Count; i++)
                    {
                        availableAmount = maxStack - inventory[positions[i]].GetAmount();

                        if (availableAmount > 0)
                        {
                            if (availableAmount >= remaining)
                            {
                                inventory[positions[i]].AddItem(item, remaining, icon);
                                remaining = 0;
                                emptySlots--;
                                break;
                            }
                            else
                            {
                                inventory[positions[i]].AddItem(item, availableAmount, icon);
                                remaining = remaining - availableAmount;
                                emptySlots--;
                            }
                        }
                    }

                    if (remaining > 0)
                    {
                        //inventory full
                    }

                }
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
            }
        }
        else
        {
            if (emptySlots == 0)
            {
                //inventory full cant handle more
                //deal with the remaining that needs to be added
            }
            else
            {
                for (int i = 0; i < inventorySize; i++)
                {
                    if (inventory[i].GetName() == "")
                    {
                        positions.Add(i);
                    }
                }

                for (int i = 0; i < positions.Count; i++)
                {
                    availableAmount = maxStack - inventory[positions[i]].GetAmount();

                    if (availableAmount > 0)
                    {
                        if (availableAmount >= remaining)
                        {
                            inventory[positions[i]].AddItem(item, remaining, icon);
                            emptySlots--;
                            remaining = 0;
                            break;
                        }
                        else
                        {
                            inventory[positions[i]].AddItem(item, availableAmount, icon);
                            remaining = remaining - availableAmount;
                            emptySlots--;
                        }
                    }
                }

                if (remaining > 0)
                {
                    //inventory full
                }

            }

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
    }

    public bool RemoveFromInventory(string item, float amount)
    {
        bool inInventory = false;
        int itemStatus = 0;
        float remaining = amount;
        float availableAmount = 0;
        List<int> positions = new List<int>();

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                inInventory = true;
                positions.Add(i);
            }
        }
        if (inInventory)
        {
            availableAmount = this.GetItemAmount(item);
            if (availableAmount >= remaining)
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    availableAmount = inventory[positions[i]].GetAmount();
                    if (availableAmount >= remaining)
                    {
                        itemStatus = inventory[positions[i]].RemoveAmount(remaining);
                        remaining = 0;
                        if (itemStatus == 1)
                        {
                            emptySlots++;
                        }
                        break;
                    }
                    else
                    {
                        itemStatus = inventory[positions[i]].RemoveAmount(availableAmount);
                        remaining = remaining - availableAmount;
                        emptySlots++;
                    }
                }
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }
            else
            {
                return false;
                //not enough

            }

        }

        return false;
    }

    public float GetItemAmount(string item)
    {
        float amount = 0;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                amount += inventory[i].GetAmount();
            }
        }

        return amount;
    }

    public Sprite GetItemSprite(string item)
    {
        Sprite icon = null;

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i].GetName() == item)
            {
                icon = inventory[i].GetIcon();
                break;
            }
        }

        return icon;
    }

    public void SelectedItem(string item)
    {
        if (item != null)
        {
            _selectedItem = item;
        }
        else
        {
            _selectedItem = "";
        }

    }

    
    private void FillSlots(int i, InventorySlotSystem invItem)
    {
        if(inventory[i].GetName() != "")
        {
            invItem.AddItem(inventory[i]);
        }
    }

}
