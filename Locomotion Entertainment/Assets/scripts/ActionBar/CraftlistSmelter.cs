using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftlistSmelter : MonoBehaviour
{
    public GameObject SmelterPanel;
    public GameObject CraftSlot;
    
    Color selected, normal;

    private List<CraftRecipe> recipes;
    private ItemList _itemList;
    private GameObject _manager;
    // Start is called before the first frame update
    void Start()
    {
        recipes = new List<CraftRecipe>();
        _manager = GameObject.FindGameObjectWithTag("GameManager");
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
            if (items[i].GetStation() == "Smelter")
            {
                recipes.Add(new CraftRecipe(items[i].GetName(), items[i].GetComponentsList()));
            }
        }

        CreateSlots();
    }

    private void CreateSlots()
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            string product = recipes[i].GetProduct();
            GameObject instance = Instantiate(CraftSlot, SmelterPanel.transform);
            instance.transform.parent = SmelterPanel.transform;
            instance.transform.Find("Text").GetComponent<Text>().text = product;
            instance.transform.Find("Image").GetComponent<Image>().sprite = _itemList.GetIcon(product);
            Button buttonEvent = instance.GetComponent<Button>();
            buttonEvent.onClick.AddListener(() =>
            {
                Debug.Log(product);
            }
            );
            
        }
        
    }

}
