using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletSystem : MonoBehaviour
{
    public GameObject tablet_Panel;
    private GameObject player;
    [SerializeField]
    private Text textInput;
    [SerializeField]
    private string message;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            tablet_Panel.SetActive(true);
            textInput.text = message;
        }
    }

}
