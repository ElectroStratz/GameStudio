using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public List<CraftRecipe> recipes;
    private ItemList _itemList;
    private GameObject _manager;
    private PlayerInv _inventory;
    private CraftRecipe _selectedRecipe;

    // Start is called before the first frame update
    void Start()
    {
        recipes = new List<CraftRecipe>();
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _inventory = _manager.GetComponent<PlayerInv>();
        _itemList = _manager.GetComponent<ItemList>();

        StartCoroutine(WaitRecipes());
    }

    IEnumerator WaitRecipes()
    {
        yield return new WaitUntil(() => _itemList.GetList().Count > 0);
        GetRecipes();
    }

    private void GetRecipes()
    {
        var items = new List<ItemInfo>(_itemList._items);
        

        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].GetStation() == "Smelter")
            {
                recipes.Add(new CraftRecipe(items[i].GetName(), items[i].GetComponentsList()));
            }
        }
    }

    public void SetRecipe(string item)
    {
        foreach(CraftRecipe recipe in recipes)
        {
            if(recipe.GetProduct() == item)
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

    private void OnMouseDown()
    {
        SetRecipe("Iron Ingot");
        Craft();
    }

    public List<CraftRecipe> GetRecipeList()
    {
        return this.recipes;
    }

}
