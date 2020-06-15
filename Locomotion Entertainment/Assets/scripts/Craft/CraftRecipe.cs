using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe : MonoBehaviour
{
    private string product;
    private List<ItemComponent> components;

    public CraftRecipe(string product, List<ItemComponent> components)
    {
        this.product = product;
        this.components = components;
        
        
    }

    public string GetProduct()
    {
        return this.product;
    }

    public List<ItemComponent> GetRecipeComponents()
    {
        return this.components;
    }
}
