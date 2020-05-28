using UnityEngine;

public class InventoryUISystem : MonoBehaviour
{
    private GameObject _manager;
    private PlayerInv _Playerinventory;
    public Transform itemsParent;

    InventorySlotSystem[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _Playerinventory = _manager.GetComponent<PlayerInv>();
        _Playerinventory.onItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlotSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for(int i = 0; i<inventorySlots.Length; i++)
        {
            if(_Playerinventory.inventory[i].GetAmount() > 0)
            {
                inventorySlots[i].AddItem(_Playerinventory.inventory[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }
    }
}
