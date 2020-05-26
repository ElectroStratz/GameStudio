using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSystem : MonoBehaviour
{
    private GameObject player;
    private bool isOpen;

    [SerializeField]
    private GameObject chestPanel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        chestPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        isOpen = !isOpen;
        if (Vector3.Distance(this.transform.position, player.transform.position) < 3)
        {
            if (isOpen)
            {
                chestPanel.SetActive(true);
            }
            else
            {
                chestPanel.SetActive(false);
            }

        }
    }
}
