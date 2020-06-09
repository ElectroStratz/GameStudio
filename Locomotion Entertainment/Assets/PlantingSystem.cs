using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSystem : MonoBehaviour
{
    public static PlantingSystem instance;
    [SerializeField]
    private GameObject seedPrefab;
    private GameObject player;
    public GrowSystem growthScript;
    public bool isOccupied = false;
    public float range = 5f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 3)
        {
            if(isOccupied)
            {
                Debug.Log("Cant Plant More Here!");
            }
            else
            {
                GameObject seedTemp = Instantiate(seedPrefab, transform.position, transform.rotation);
                seedTemp.transform.parent = gameObject.transform;
                isOccupied = true;
                growthScript = seedTemp.GetComponent<GrowSystem>();
                growthScript.isPlanted = true;
            }

        }

    }

   void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
