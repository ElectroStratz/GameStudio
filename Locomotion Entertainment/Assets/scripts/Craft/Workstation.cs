using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Workstation : MonoBehaviour
{
    public GameObject SmelterPanelUI;
    public GameObject SmelterPanel;
    public GameObject CraftSlot;
    public Button craftButton;

    public List<CraftRecipe> _recipes;
    private ItemList _itemList;
    private GameObject _manager;
    private PlayerInv _inventory;
    private CraftRecipe _selectedRecipe;

    // Start is called before the first frame update
    void Start()
    {
        _recipes = new List<CraftRecipe>();
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _inventory = _manager.GetComponent<PlayerInv>();
        _itemList = _manager.GetComponent<ItemList>();
        craftButton.onClick.AddListener(() => { Craft(); });

        StartCoroutine(WaitRecipes());
    }

    IEnumerator WaitRecipes()
    {
        yield return new WaitUntil(() => _itemList.GetList().Count > 0);
        GetRecipes();
    }

    public void GetRecipes()
    {
        var items = new List<ItemInfo>(_itemList._items);


        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetStation() == "Workstation")
            {
                _recipes.Add(new CraftRecipe(items[i].GetName(), items[i].GetComponentsList()));
            }
        }

        CreateSlots();
    }

    public void SetRecipe(string item)
    {
        foreach (CraftRecipe recipe in _recipes)
        {
            if (recipe.GetProduct() == item)
            {
                _selectedRecipe = recipe;
            }
        }
    }

    public void Craft()
    {
        bool isPossible = false;
        foreach (var item in _selectedRecipe.GetRecipeComponents())
        {
            print("component name:" + item.compname);
            print("component amount:" + item.amount);
            if (_inventory.GetItemAmount(item.compname) >= item.amount)
            {
                isPossible = true;
            }
            else
            {
                isPossible = false;
                break;
            }
        }

        if (isPossible)
        {
            foreach (var item in _selectedRecipe.GetRecipeComponents())
            {
                _inventory.RemoveFromInventory(item.compname, item.amount);
            }
            _inventory.AddToInventory(_selectedRecipe.GetProduct(), 1, _itemList.GetIcon(_selectedRecipe.GetProduct()));
            print("added product to playerinv");
        }
    }
    private void CreateSlots()
    {
        for (int i = 0; i < _recipes.Count; i++)
        {
            string product = _recipes[i].GetProduct();
            GameObject instance = Instantiate(CraftSlot, SmelterPanel.transform);
            instance.transform.parent = SmelterPanel.transform;
            instance.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = product;
            instance.transform.Find("Image").GetComponent<Image>().sprite = _itemList.GetIcon(product);
            Button buttonEvent = instance.GetComponent<Button>();
            buttonEvent.onClick.AddListener(() =>
            {
                SetRecipe(product);
            }
            );

        }

    }

    void OnMouseDown()
    {
        SmelterPanelUI.SetActive(true);
        _inventory.inventoryUI.SetActive(true);
    }
}
