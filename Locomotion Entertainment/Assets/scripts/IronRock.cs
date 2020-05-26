using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronRock : MonoBehaviour
{
    private GameObject manager;
    private GameObject player;
    private PlayerInv inventory;
    [SerializeField]
    private Image hp_ui;

    private float sizeResource = 10f;
    private float currentResource;
    private bool isDepleted = false;
    private ParticleSystem particlesIron;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = manager.GetComponent<PlayerInv>();
        particlesIron = GetComponent<ParticleSystem>();
        particlesIron.Pause();
        currentResource = sizeResource;
        InvokeRepeating("GrowBack", 2f , 2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {          
        if(Vector3.Distance(this.transform.position,player.transform.position) < 3)
        {
            if(!isDepleted && currentResource > 0)
            {
                particlesIron.Play();
                inventory.AddToInventory("iron", 10);
                currentResource--;
                hp_ui.fillAmount = currentResource / sizeResource;
                this.transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            }
            else
            {
                isDepleted = true;
            }

        }
        
    }
 

    void GrowBack()
    {
        if (isDepleted)
        {
            this.transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y + 0.05f, transform.localScale.z + 0.05f);
            currentResource++;
            hp_ui.fillAmount = currentResource / sizeResource;
            if (currentResource == sizeResource)
            {
                isDepleted = false;
            }
        }
        
    }
}
