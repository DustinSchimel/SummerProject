using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;

public class MultiplayerMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject multiplayerCanvas;

    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField joinCodeInput;

    [SerializeField] private Button joinGameButton;
    [SerializeField] private Button createGameButton;
    [SerializeField] private Button backButton;

    [Header("Values")]
    [SerializeField] private int minUsernameLength = 2;
    [SerializeField] private int maxPlayerCount;
    private string savedUsername;
    private string joinCode;

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();  // this avoids having to use an account system
    }

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        if (PlayerPrefs.HasKey("savedUsername"))
        {
            Debug.Log("Saved username of " + PlayerPrefs.GetString("savedUsername") + " found");
            savedUsername = PlayerPrefs.GetString("savedUsername");
            usernameInput.text = savedUsername;

            if (savedUsername.Length >= minUsernameLength)  // Once player loads in there is no join code entered, so just enable create button
            {
                createGameButton.enabled = true;
                createGameButton.Select();
            }
            else
            {
                backButton.Select();
            }
        }
        else
        {
            Debug.Log("No saved username found");
            savedUsername = "";
            backButton.Select();
        }
    }

    public void GoBack()
    {
        multiplayerCanvas.SetActive(false); // Disables the multiplayer menu
        mainMenu.SetActive(true);    // Enables the main menu

        if (usernameInput.text.Length >= minUsernameLength)
        {
            SaveUsername();
        }
    }

    public void OnUsernameUpdated()
    {
        if (usernameInput.text.Length >= minUsernameLength)
        {
            createGameButton.interactable = true;
        }
        else
        {
            createGameButton.interactable = false;
            joinGameButton.interactable = false;
        }
    }

    public void OnJoinCodeUpdated()
    {
        if (joinCodeInput.text.Length == 6)
        {
            joinGameButton.interactable = true;
        }
        else
        {
            joinGameButton.interactable = false;
        }
    }

    public void OnDeselectJoinField()
    {
        if (joinCodeInput.text.Length == 6)
        {
            joinGameButton.Select();
        }
        else
        {

        }
    }

    public async void CreateGame()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxPlayerCount - 1);   // - 1 since host is not counted

            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();

            NetworkManager.Singleton.SceneManager.LoadScene("multiplayer", LoadSceneMode.Single);

            SaveUsername();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    public async void JoinGame()
    {
        try
        {
            joinCode = joinCodeInput.text;

            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();

            SaveUsername();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    private void SaveUsername()
    {
        savedUsername = usernameInput.text;
        Debug.Log("Saving username of " + savedUsername);
        PlayerPrefs.SetString("savedUsername", savedUsername);
    }
}