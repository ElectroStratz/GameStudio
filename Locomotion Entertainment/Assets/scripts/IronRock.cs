using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronRock : MonoBehaviour
{
    private GameObject manager;
    private GameObject player;
    private PlayerInv inventory;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = manager.GetComponent<PlayerInv>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {          
        if(Vector3.Distance(this.transform.position,player.transform.position) < 3)
        {
            inventory.AddToInventory("iron", 10);
        }
        
    }
}
