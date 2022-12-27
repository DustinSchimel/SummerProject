using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour
{
    [Header("References")]
    private PlayersManager playersManager;
    
    [SerializeField] public TMP_Text joinCodeField;
    [SerializeField] private TMP_Text playerCountText;

    void Start()
    {
        playersManager = FindObjectOfType<PlayersManager>();
        joinCodeField.text = "Code: " + playersManager.JoinCode;
    }

    void Update()
    {
        playerCountText.text =  "Players: " + playersManager.PlayersInGame.ToString();
    }
}
