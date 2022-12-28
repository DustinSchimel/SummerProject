using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Collections;

public class PlayersManager : NetworkBehaviour
{
    public static PlayersManager instance;

    private NetworkVariable<int> playerCount = new NetworkVariable<int>();
    private NetworkVariable<FixedString32Bytes> joinCode = new NetworkVariable<FixedString32Bytes>();
    private string joinCodeTempHolder;

    public int PlayersInGame
    {
        get
        {
            return playerCount.Value;
        }
    }

    public string JoinCode
    {
        get
        {
            return joinCode.Value.ToString();
        }
    }

    void Awake () 
    {
        if (instance == null) 
        {
            instance = this;
        } 
        else if (instance != this)
        {
            Destroy(gameObject);
        }
 
       DontDestroyOnLoad (gameObject);
    }

    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            if (NetworkManager.Singleton.IsHost)
            {
               playerCount.Value++;
            }
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            if (NetworkManager.Singleton.IsHost)
            {
               playerCount.Value--;
            }
        };

        NetworkManager.Singleton.OnServerStarted += () =>
        {
            if (NetworkManager.Singleton.IsHost)
            {
               joinCode.Value = joinCodeTempHolder;
            }
        };
    }

    // This is here because the server variable cannot be updated before the server starts
    public void SetJoinCode(string code)
    {
        joinCodeTempHolder = code;
    }

    public void Cleanup()
    {
        playerCount.Value = 0;
    }
}
