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

    [Header("Values")]
    public int minUsernameLength = 2;
    public byte maxPlayersPerRoom = 10;
    private int optionSelected;
    private string savedUsername;
    private bool inJoinHostMenu = false;

    [SerializeField] private string versionName = "0.2-alpha";

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Menu.Enable();
        playerInputActions.Menu.MoveUp.performed += MoveUp;
        playerInputActions.Menu.MoveDown.performed += MoveDown;
        playerInputActions.Menu.SelectOption.performed += SelectOption;

        optionSelected = 2; // take out once username saving is in
        backButton.Select();    // take out once username saving is in

        /*
        if (PlayerPrefs.HasKey("savedUsername"))
        {
            savedUsername = PlayerPrefs.GetString("savedUsername");
            usernameInput.text = savedUsername;

            if (savedUsername.Length >= minUsernameLength)
            {
                optionSelected = 1;
                continueButton.enabled = true;
                continueButton.Select();
            }
        }
        else
        {
            savedUsername = "";
            optionSelected = 0;
            usernameInput.Select();
        }
        */
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Username Input' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 1)   // 'Continue' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 2)   // 'Back Button' is selected
        {
            if (continueButton.isActiveAndEnabled)
            {
                continueButton.Select();

                optionSelected = 1;
            }
            else
            {
                backButton.Select();
            }
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Username Input' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 1)    // 'Continue Button' is selected
        {
            // Enable 'Back' selection
            backButton.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)    // 'Back' is selected
        {
            backButton.Select();
        }
    }

    public void SelectOption(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Isername Input' is selected
        {
            // Not too sure yet
        }
        else if (optionSelected == 1)   // 'Continue' is selected
        {
            // Load multiplayer stuff

            playerInputActions.Menu.Disable();
            mainMenu.SetActive(false);    // Disables the main menu
            hostJoinMenu.SetActive(true);    // Enables the multiplayer menu
        }
        else if (optionSelected == 2)   // 'Back' is selected
        {
            GoBack();
        }
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

        if (PhotonNetwork.connected)
        {
            PhotonNetwork.Disconnect(); // Not working properly for some reason
        }

        mainMenu.SetActive(true);    // Enables the main menu
    }

    public void ChangeUsernameInput()
    {
        if (usernameInput.text.Length >= minUsernameLength)
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            if (optionSelected == 1)
            {
                optionSelected = 2;
            }

            continueButton.gameObject.SetActive(false);
        }
    }

    public void SetUserName()
    {
        hostJoinMenu.SetActive(true);
        usernameMenu.SetActive(false);
        PhotonNetwork.playerName = usernameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(hostGameInput.text, new RoomOptions() { maxPlayers = maxPlayersPerRoom}, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = maxPlayersPerRoom;
        PhotonNetwork.JoinOrCreateRoom(joinGameInput.text, roomOptions, TypedLobby.Default);    // Attempts to join room, but if that room does not exists, then one is created with that name
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Multiplayer");
    }

    /*
    public void SaveUsername()
    {
        // Save username
        PlayerPrefs.SetString("savedUsername", savedUsername);
    }
    */
}