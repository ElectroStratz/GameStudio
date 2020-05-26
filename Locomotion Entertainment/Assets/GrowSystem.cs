using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSystem : MonoBehaviour
{
    private PlayerInv inventory;
    private GameObject manager;

    public static GrowSystem instance;
    private float growth;
    public PlantingSystem plantingScript;
    [SerializeField]
    public bool isPlanted = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        manager = GameObject.FindGameObjectWithTag("GameManager");
        inventory = manager.GetComponent<PlayerInv>();
        if (isPlanted)
        {
            plantingScript = gameObject.GetComponentInParent<PlantingSystem>();
                InvokeRepeating("Growth", 5, 5);


        }
    }
    void Growth()
    {
        if (growth < 5)
        {
            gameObject.transform.localScale = new Vector3(0.2f, transform.localScale.y + 1f, 0.2f);
        growth++;
        }
            else
        {
            Debug.Log("Ready to Harvest");
        }
    }

    void OnMouseDown()
    {
        if (growth == 5)
        {
            plantingScript.isOccupied = false;
            Destroy(gameObject);
            inventory.AddToInventory("food", 3, null);
        }
        else
        {
            Debug.Log("Cant harvest yet!");
        }

    }
}
