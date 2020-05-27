using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBarUISystem : MonoBehaviour
{
    private GameObject _manager;
    private PlayerActionBar _Playeractionbar;
    public Transform itemsParent;

    ActionBarSlotSystem[] actionbarSlots;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _Playeractionbar = _manager.GetComponent<PlayerActionBar>();
        _Playeractionbar.onItemChangedCallback += UpdateUI;
        actionbarSlots = itemsParent.GetComponentsInChildren<ActionBarSlotSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < actionbarSlots.Length; i++)
        {
            if (_Playeractionbar.actionbarItem[i].GetAmount() > 0)
            {
                actionbarSlots[i].AddItem(_Playeractionbar.actionbarItem[i]);
            }
            else
            {
                actionbarSlots[i].ClearSlot();
            }

        }
    }
}
