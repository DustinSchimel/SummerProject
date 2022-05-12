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
    public GameObject hostJoinMenu;

    public TMP_InputField usernameInput;
    public TMP_InputField hostGameInput;
    public TMP_InputField joinGameInput;

    public Button continueButton;
    public Button backButton;

    [Header("Values")]
    public int minUsernameLength = 2;
    private int optionSelected;
    private string savedUsername;

    [SerializeField] private string versionName = "0.1";
    [SerializeField] private 

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
        /*
        playerInputActions = new PlayerInputActions();
        playerInputActions.TitleScreen.Enable();
        playerInputActions.TitleScreen.MoveUp.performed += MoveUp;
        playerInputActions.TitleScreen.MoveDown.performed += MoveDown;
        playerInputActions.TitleScreen.SelectOption.performed += SelectOption;
        */

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
        /*
        if (optionSelected == 0)    // 'Username Input' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 1)   // 'Continue' is selected
        {
            // Enable 'Username Input' selection
            usernameInput.Select();

            optionSelected = 0;
        }
        else if (optionSelected == 2)   // 'Back Button' is selected
        {
            if (continueButton.isActiveAndEnabled)
            {
                // Enable 'Continue Button' selection
                continueButton.Select();

                optionSelected = 1;
            }
            else
            {
                // Enable 'Username Input' selection
                usernameInput.Select();

                optionSelected = 0;
            }
        }
        */
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        /*
        if (optionSelected == 0)    // 'Username Input' is selected
        {
            if (continueButton.isActiveAndEnabled)
            {
                // Enable 'Continue Button' selection
                continueButton.Select();

                optionSelected = 1;
            }
            else
            {
                // Enable 'Back Button' selection
                backButton.Select();

                optionSelected = 2;
            }
        }
        else if (optionSelected == 1)    // 'Continue Button' is selected
        {
            // Enable 'Back' selection
            backButton.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)    // 'Back' is selected
        {
            // Do nothing
        }
        */
    }

    public void SelectOption(InputAction.CallbackContext context)
    {
        /*
        if (optionSelected == 0)    // 'Isername Input' is selected
        {
            // Not too sure yet
        }
        else if (optionSelected == 1)   // 'Continue' is selected
        {
            // Load multiplayer stuff


            //playerInputActions.TitleScreen.Disable();
            //multiplayerMenu.SetActive(true);    // Enables the multiplayer menu
            //mainMenu.SetActive(false);    // Disables the main menu
        }
        else if (optionSelected == 2)   // 'Back' is selected
        {
            //playerInputActions.TitleScreen.Disable();
            mainMenu.SetActive(true);    // Enables the main menu
            usernameMenu.SetActive(false);    // Disables the multiplayer menu
        }
        */
    }

    public void OnDisable()
    {
        optionSelected = 0;
        playerInputActions.TitleScreen.Disable();
    }

    public void ChangeUsernameInput()
    {
        if (usernameInput.text.Length >= minUsernameLength)
        {
            //continueButton.enabled = true;
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
            //continueButton.enabled = false;
        }
    }

    public void SetUserName()
    {
        usernameMenu.SetActive(false);
        hostJoinMenu.SetActive(true);
        PhotonNetwork.playerName = usernameInput.text;
    }

    /*
    public void SaveUsername()
    {
        // Save username
        PlayerPrefs.SetString("savedUsername", savedUsername);
    }
    */
}