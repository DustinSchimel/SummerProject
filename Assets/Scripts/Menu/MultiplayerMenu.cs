using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class MultiplayerMenu : MonoBehaviour
{
    [Header("References")]
    private PlayerInputActions playerInputActions;
    public GameObject mainMenu;
    public GameObject usernameMenu;
    public GameObject multiplayerCanvas;
    public GameObject hostJoinMenu;

    public TMP_InputField usernameInput;
    public TMP_InputField hostGameInput;
    public TMP_InputField joinGameInput;

    public Button continueButton;
    public Button backButton;

    public Button connectBackButton;
    public Button joinGameButton;
    public Button createGameButton;

    [Header("Values")]
    public int minUsernameLength = 2;
    public byte maxPlayersPerRoom = 10;
    private int optionSelected;
    private string savedUsername;
    private bool inConnectMenu = false;

    [SerializeField] private string versionName = "0.2-alpha";

    void Awake()
    {
        /*
        PhotonNetwork.ConnectUsingSettings(versionName);
        */
    }

    private void OnConnectedToMaster()
    {
        /*
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
        */
    }

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Menu.Enable();
        playerInputActions.Menu.MoveUp.performed += MoveUp;
        playerInputActions.Menu.MoveDown.performed += MoveDown;
        playerInputActions.Menu.SelectOption.performed += SelectOption;

        if (PlayerPrefs.HasKey("savedUsername") && PlayerPrefs.GetString("savedUsername").Length >= minUsernameLength)
        {
            Debug.Log("Saved username of " + PlayerPrefs.GetString("savedUsername") + " found");
            savedUsername = PlayerPrefs.GetString("savedUsername");
            usernameInput.text = savedUsername;

            if (savedUsername.Length >= minUsernameLength)
            {
                optionSelected = 0;
                continueButton.enabled = true;
                continueButton.Select();
            }
        }
        else
        {
            Debug.Log("No saved username found");
            savedUsername = "";
            optionSelected = 1;
            backButton.Select();
        }
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        if (!inConnectMenu)
        {
            if (optionSelected == 0)   // 'Continue' is selected
            {
                continueButton.Select();
            }
            else if (optionSelected == 1)   // 'Back Button' is selected
            {
                if (continueButton.isActiveAndEnabled)
                {
                    continueButton.Select();

                    optionSelected = 0;
                }
                else
                {
                    backButton.Select();
                }
            }
        }
        else
        {
            if (optionSelected == 0)    // 'Create Game Button' is selected
            {
                createGameButton.Select();
            }
            else if (optionSelected == 1)   // 'Join Game Button' is selected
            {
                createGameButton.Select();

                optionSelected = 0;
            }
            else if (optionSelected == 2)   // 'Back Button' is selected
            {
                joinGameButton.Select();

                optionSelected = 1;
            }
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (!inConnectMenu)
        {
            if (optionSelected == 0)    // 'Continue Button' is selected
            {
                backButton.Select();

                optionSelected = 1;
            }
            else if (optionSelected == 1)    // 'Back Button' is selected
            {
                backButton.Select();
            }
        }
        else
        {
            if (optionSelected == 0)    // 'Create Game Button' is selected
            {
                joinGameButton.Select();

                optionSelected = 1;
            }
            else if (optionSelected == 1)   // 'Join Game Button' is selected
            {
                connectBackButton.Select();

                optionSelected = 2;
            }
            else if (optionSelected == 2)   // 'Back Button' is selected
            {
                connectBackButton.Select();
            }
        }
    }

    public void SelectOption(InputAction.CallbackContext context)
    {
        if (!inConnectMenu)
        {
            if (optionSelected == 0)    // 'Continue Button' is selected
            {
                SetUserName();
            }
            else if (optionSelected == 1)   // 'Back Button' is selected
            {
                GoBack();
            }
        }
        else
        {
            if (optionSelected == 0)    // 'Create Game Button' is selected
            {
                CreateGame();
            }
            else if (optionSelected == 1)   // 'Join Game Button' is selected
            {
                JoinGame();
            }
            else if (optionSelected == 2)   // 'Back Button' is selected
            {
                GoBackConnectMenu();
            }
        }
    }

    public void DisableInput()
    {
        playerInputActions.Menu.Disable();
    }

    public void EnableInput()
    {
        playerInputActions.Menu.Enable();
    }

    public void OnDisconnectedFromPhoton()
    {
        Debug.Log("Disconnected");
    }

    public void GoBack()
    {
        playerInputActions.Menu.Disable();

        usernameMenu.SetActive(false);    // Disables the multiplayer menu
        multiplayerCanvas.SetActive(false); // Disables the multiplayer canvas so the player can reconnect once they enter the multiplayer menu again

        /*
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.Disconnect(); // Not working properly for some reason
        }
        */

        mainMenu.SetActive(true);    // Enables the main menu
    }

    public void GoBackConnectMenu()
    {
        hostJoinMenu.SetActive(false);  // Disables the host join menu
        usernameMenu.SetActive(true);    // Enables the username menu

        inConnectMenu = false;
        optionSelected = 1;
    }

    public void ChangeUsernameInput()
    {
        if (usernameInput.text.Length >= minUsernameLength)
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            if (optionSelected == 0)
            {
                optionSelected = 1;
            }

            continueButton.gameObject.SetActive(false);
        }
    }

    public void SetUserName()
    {
        /*
        usernameMenu.SetActive(false);
        hostJoinMenu.SetActive(true);
        PhotonNetwork.playerName = usernameInput.text;

        inConnectMenu = true;
        optionSelected = 0;
        createGameButton.Select();
        */
    }

    public void CreateGame()    //add checks for input is empty
    {
        if (hostGameInput.text.ToLower().Length > 0)
        {
            /*
            SaveUsername();
            playerInputActions.Menu.Disable();
            PhotonNetwork.CreateRoom(hostGameInput.text.ToLower(), new RoomOptions() { maxPlayers = maxPlayersPerRoom }, null);
            inConnectMenu = false;
            optionSelected = 1;
            */
        }
    }

    public void JoinGame()
    {
        if (joinGameInput.text.ToLower().Length > 0)
        {
            /*
            SaveUsername();
            playerInputActions.Menu.Disable();
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.maxPlayers = maxPlayersPerRoom;
            PhotonNetwork.JoinOrCreateRoom(joinGameInput.text.ToLower(), roomOptions, TypedLobby.Default);    // Attempts to join room, but if that room does not exists, then one is created with that name
            inConnectMenu = false;
            optionSelected = 1;
            */
        }
    }

    private void OnJoinedRoom()
    {
        /*
        PhotonNetwork.LoadLevel("Multiplayer");
        */
    }

    public void SaveUsername()
    {
        // Save username
        savedUsername = usernameInput.text;
        Debug.Log("Saving username of " + savedUsername);
        PlayerPrefs.SetString("savedUsername", savedUsername);
    }
}