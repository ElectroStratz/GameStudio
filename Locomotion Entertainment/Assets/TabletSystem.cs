using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletSystem : MonoBehaviour
{
    public GameObject tablet_Panel;
    private GameObject player;
    [SerializeField]
    private TextMeshProUGUI textInput;
    [SerializeField]
    private TextMeshProUGUI titleInput;
    [SerializeField]
    private string message;
    [SerializeField]
    private string Title;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            tablet_Panel.SetActive(true);
            titleInput.text = Title;
            textInput.text = message;
        }
    }

}
