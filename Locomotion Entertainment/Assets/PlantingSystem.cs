using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSystem : MonoBehaviour
{
    public static PlantingSystem instance;
    [SerializeField]
    private GameObject[] seedPrefabArray;
    private GameObject player;
    private Animator _playeranimator;
    private AudioSource _audiosource;
    public GrowSystem growthScript;
    public bool isOccupied = false;
    public float range = 5f;


    GameObject _manager;
    PlayerInv _playerInv;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameManager");
        _playerInv = _manager.GetComponent<PlayerInv>();
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        _playeranimator = player.GetComponentInChildren<Animator>();
        _audiosource = GetComponent<AudioSource>();
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
                if (_playerInv.GetItemAmount("Biomass") > 0)
                {
                    GameObject seed;
                    float rand = Random.Range(0, 1);
                    if(rand <= 0.33f)
                    {
                        seed = seedPrefabArray[0];
                    }
                    else if (rand <= 0.66f)
                    {
                        seed = seedPrefabArray[1];
                    }
                    else
                    {
                        seed = seedPrefabArray[2];
                    }
                    _playeranimator.SetTrigger("Planting");
                    StartCoroutine("ShovelSound");
                    GameObject seedTemp = Instantiate(seed, transform.position, transform.rotation);
                    seedTemp.transform.parent = gameObject.transform;
                    isOccupied = true;
                    growthScript = seedTemp.GetComponent<GrowSystem>();
                    growthScript.isPlanted = true;

                }
            }

        }

    }

   void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private IEnumerator ShovelSound()
    {
        yield return new WaitForSeconds(0.65f);
        _audiosource.Play();
    }
}
