using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour
{
    [Header("References")]
    private PlayersManager playersManager;

    [SerializeField] private TMP_Text joinCodeField;
    [SerializeField] private TMP_Text playerCountText;

    // Start is called before the first frame update
    void Start()
    {
        playersManager = FindObjectOfType<PlayersManager>();
        joinCodeField.text = "Code: " + playersManager.JoinCode;
    }

    // Update is called once per frame
    void Update()
    {
        //playerCountText.text =  "Player Count: " + PlayersManager.instance.PlayersInGame.ToString();
        playerCountText.text =  "Players: " + playersManager.PlayersInGame.ToString();
    }
}
