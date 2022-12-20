using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private int maxPlayerCount;
    private string joinCode;

    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private TMP_InputField joinCodeField;
    [SerializeField] private TMP_Text displayCode;

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();  // this avoids having to use an account system
    }

    public async void CreateRelay()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxPlayerCount - 1);   // - 1 since host is not counted

            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();

            toggleUIElements();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    public async void JoinRelay()
    {
        try
        {
            joinCode = joinCodeField.text;

            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();

            toggleUIElements();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    public void onJoinCodeUpdated()
    {
        if (joinCodeField.text.Length == 6)
        {
            clientButton.interactable = true;
        }
        else
        {
            clientButton.interactable = false;
        }
    }

    private void toggleUIElements()
    {
        hostButton.gameObject.SetActive(false);
        clientButton.gameObject.SetActive(false);
        joinCodeField.gameObject.SetActive(false);

        displayCode.gameObject.SetActive(true);
        displayCode.text = joinCode;
    }
}
