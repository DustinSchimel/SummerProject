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
using System.Collections;

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
    [SerializeField] private GameObject invalidCodeText;
    [SerializeField] private GameObject connectingText;

    private PlayersManager playersManager;

    [Header("Values")]
    [SerializeField] private int minUsernameLength = 2;
    [SerializeField] private int maxPlayerCount;
    private string savedUsername;
    private string joinCode;

    private bool signedIn = false;
    private IEnumerator errorCoroutine;

    private void Awake()
    {
        playersManager = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
                signedIn = true;

                if (usernameInput.text.Length >= minUsernameLength)
                {
                    createGameButton.interactable = true;

                    if (joinCodeInput.text.Length == 6)
                    {
                        joinGameButton.interactable = true;
                    }
                }
            };
            AuthenticationService.Instance.SignedOut += () =>
            {
                Debug.Log("Signed out " + AuthenticationService.Instance.PlayerId);
                signedIn = false;
                createGameButton.interactable = false;
                joinGameButton.interactable = false;
            };
            await AuthenticationService.Instance.SignInAnonymouslyAsync();  // this avoids having to use an account system
        }
        else
        {
            signedIn = true;

            if (savedUsername.Length >= minUsernameLength)  // This is needed since OnEnable happens before Start and signedIn is set
            {
                createGameButton.interactable = true;
                createGameButton.Select();
            }
        }
    }

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        if (PlayerPrefs.HasKey("savedUsername"))
        {
            Debug.Log("Saved username of " + PlayerPrefs.GetString("savedUsername") + " found");
            savedUsername = PlayerPrefs.GetString("savedUsername");
            usernameInput.text = savedUsername;

            if (savedUsername.Length >= minUsernameLength && signedIn)  // Once player loads in there is no join code entered, so just enable create button
            {
                createGameButton.interactable = true;
                // set enabled originally
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
        StopCoroutine(errorCoroutine);
        connectingText.SetActive(false);
        invalidCodeText.SetActive(false);

        multiplayerCanvas.SetActive(false); // Disables the multiplayer menu
        mainMenu.SetActive(true);    // Enables the main menu

        if (usernameInput.text.Length >= minUsernameLength)
        {
            SaveUsername();
        }
    }

    public void OnUsernameUpdated()
    {
        if (usernameInput.text.Length >= minUsernameLength && signedIn)
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
        if (joinCodeInput.text.Length == 6 && signedIn)
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
            SceneManager.LoadScene("multiplayer", LoadSceneMode.Single);    // Might be best way to go

            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxPlayerCount - 1);   // - 1 since host is not counted

            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            //PlayersManager.instance.Cleanup();
            //PlayersManager.instance.SetJoinCode(joinCode);
            playersManager.SetJoinCode(joinCode);

            // Temporary solution for updating the host with the join code in UI
            NetworkUI tempUIReference = FindObjectOfType<NetworkUI>();
            tempUIReference.joinCodeField.text = "Code: " + joinCode;

            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();

            SaveUsername();

            //FindObjectOfType<PlayerStats>().updateUsername(usernameInput.text);
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
            invalidCodeText.SetActive(false);
            connectingText.SetActive(true);

            joinCode = joinCodeInput.text;

            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();

            SaveUsername();

            //FindObjectOfType<PlayerStats>().updateUsername(usernameInput.text);
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
            Debug.Log(e.ErrorCode);

            if (e.ErrorCode == 15001 || e.ErrorCode == 15009)   // This means an invalid code was entered
            {
                connectingText.SetActive(false);
                invalidCodeText.SetActive(true);

                
                if (errorCoroutine != null)
                {
                    StopCoroutine(errorCoroutine);
                }

                errorCoroutine = ErrorCoroutine();
                StartCoroutine(errorCoroutine);
            }
        }
    }

    IEnumerator ErrorCoroutine()
    {
        yield return new WaitForSeconds(5f);

        invalidCodeText.SetActive(false);
    }

    private void SaveUsername()
    {
        savedUsername = usernameInput.text;
        Debug.Log("Saving username of " + savedUsername);
        PlayerPrefs.SetString("savedUsername", savedUsername);
    }
}