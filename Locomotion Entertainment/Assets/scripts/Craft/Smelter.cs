﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public List<CraftRecipe> _recipes;
    private ItemList _itemList;
    private GameObject _manager;
    private PlayerInv _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _recipes = new List<CraftRecipe>();
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

    public void GetRecipes()
    {
        var items = new List<ItemInfo>(_itemList._items);
        

        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].GetStation() == "Smelter")
            {
                _recipes.Add(new CraftRecipe(items[i].GetName(), items[i].GetComponentsList()));
            }
        }
    }

    private void OnMouseDown()
    {
        print("smelter mouse down");
        //Iron Ingot
        string product = _recipes[0].GetProduct();
        print(product);
        //Iron Ore
        List<ItemComponent> recipeComponents = _recipes[0].components;

        bool isPossible = false;
        print("item1:"+recipeComponents.Count);
        print("item2:"+recipeComponents[0].amount);
        foreach (var item in recipeComponents)
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
            foreach (var item in recipeComponents)
            {
                _inventory.RemoveFromInventory(item.compname,item.amount);
            }

            _inventory.AddToInventory(product, 1, _itemList.GetIcon(product));
            print("added product to playerinv");
        }
    }

}
