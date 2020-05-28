using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refinery_System : MonoBehaviour
{
    public GameObject refineryPanel;
    bool isOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            refineryPanel.SetActive(true);
        }
        else
        {
            refineryPanel.SetActive(false);
        }
    }
}
