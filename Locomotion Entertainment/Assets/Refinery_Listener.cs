using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery_Listener : MonoBehaviour
{
    public GameObject _manager;
    Refinery_System refinery;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        refinery = _manager.GetComponent<Refinery_System>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            refinery.CheckRefineryLocation();
        }
    }
}
