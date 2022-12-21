using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using UnityEditor;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;

public class MultiplayerMenu : MonoBehaviour
{
    [Header("References")]
    private PlayerInputActions playerInputActions;
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
    private int optionSelected;
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
        playerInputActions = new PlayerInputActions();
        playerInputActions.Menu.Enable();
        playerInputActions.Menu.MoveUp.performed += MoveUp;
        playerInputActions.Menu.MoveDown.performed += MoveDown;
        playerInputActions.Menu.SelectOption.performed += SelectOption;

        if (PlayerPrefs.HasKey("savedUsername"))
        {
            Debug.Log("Saved username of " + PlayerPrefs.GetString("savedUsername") + " found");
            savedUsername = PlayerPrefs.GetString("savedUsername");
            usernameInput.text = savedUsername;

            if (savedUsername.Length >= minUsernameLength)  // Once player loads in there is no join code entered, so just enable create button
            {
                optionSelected = 1;
                createGameButton.enabled = true;
                createGameButton.Select();
            }
        }
        else
        {
            Debug.Log("No saved username found");
            savedUsername = "";
            optionSelected = 2;
            backButton.Select();
        }
    }

    private void MoveUp(InputAction.CallbackContext context) // may have to make these public again
    {
        if (optionSelected == 0)    // 'Join Game' Button is selected
        {
            joinGameButton.Select();
        }
        else if (optionSelected == 1)   // 'Create Game' Button is selected
        {
            if (joinGameButton.enabled == true)
            {
                joinGameButton.Select();

                optionSelected = 0;
            }
        }
        else if (optionSelected == 2)   // 'Back' Button is selected
        {
            if (createGameButton.enabled == true)
            {
                createGameButton.Select();

                optionSelected = 1;
            }
        }
    }

    private void MoveDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Join Game' Button is selected
        {
            createGameButton.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 1)   // 'Create Game' Button is selected
        {
            backButton.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)   // 'Back' Button is selected
        {
            backButton.Select();
        }
    }

    private void SelectOption(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Join Game' Button is selected
        {
            if ((joinCodeInput.text.Length == 6) && (savedUsername.Length >= minUsernameLength))    // double checking, should remove this later
            {
                JoinGame();
            }
        }
        else if (optionSelected == 1)   // 'Create Game' Button is selected
        {
            if (savedUsername.Length >= minUsernameLength)    // double checking, should remove this later
            {
                CreateGame();
            }
        }
        else if (optionSelected == 2)   // 'Back' Button is selected
        {
            GoBack();
        }
    }

    private void DisableInput()
    {
        playerInputActions.Menu.Disable();
    }

    private void EnableInput()
    {
        playerInputActions.Menu.Enable();
    }

    private void GoBack()
    {
        playerInputActions.Menu.Disable();

        multiplayerCanvas.SetActive(false); // Disables the multiplayer menu
        mainMenu.SetActive(true);    // Enables the main menu

        ResetMenuState();
    }

    private void ResetMenuState()
    {

    }

    private void OnUsernameUpdated()
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

            ResetMenuState();
            SaveUsername();
            playerInputActions.Menu.Disable();
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

            ResetMenuState();
            SaveUsername();
            playerInputActions.Menu.Disable();
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