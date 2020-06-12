using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workstation : MonoBehaviour
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
            if (items[i].GetStation() == "Workstation")
            {
                _recipes.Add(new CraftRecipe(items[i].GetName(), items[i].GetComponentsList()));
            }
        }
    }
}
