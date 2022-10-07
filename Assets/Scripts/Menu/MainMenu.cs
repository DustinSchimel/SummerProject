using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("References")]
    private PlayerInputActions playerInputActions;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject multiplayerMenu;
    public GameObject multiplayerCanvas;

    public Button timeTrialButton;
    public Button multiplayerButton;
    public Button settingsButton;
    public Button quitButton;

    [Header("Values")]
    private int optionSelected;

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Menu.Enable();
        playerInputActions.Menu.MoveUp.performed += MoveUp;
        playerInputActions.Menu.MoveDown.performed += MoveDown;
        playerInputActions.Menu.SelectOption.performed += SelectOption;

        optionSelected = 0;
        timeTrialButton.Select();
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Time Trial' is selected
        {
            timeTrialButton.Select();
        }
        else if (optionSelected == 1)   // 'Multiplayer' is selected
        {
            timeTrialButton.Select();

            optionSelected = 0;
        }
        else if (optionSelected == 2)   // 'Settings' is selected
        {
            multiplayerButton.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 3)   // 'Quit' is selected
        {
            settingsButton.Select();

            optionSelected = 2;
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Time Trial' is selected
        {
            multiplayerButton.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 1)    // 'Multiplayer' is selected
        {
            settingsButton.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)    // 'Settings' is selected
        {
            quitButton.Select();

            optionSelected = 3;
        }
        else if (optionSelected == 3)    // 'Quit' is selected
        {
            quitButton.Select();
        }
    }

    public void SelectOption(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Time Trial' is selected
        {
            PlayTimeTrial();
        }
        else if (optionSelected == 1)   // 'Multiplayer' is selected
        {
            GoToMultiplayer();
        }
        else if (optionSelected == 2)   // 'Settings' is selected
        {
            GoToSettings();
        }
        else if (optionSelected == 3)   // 'Quit' is selected
        {
            QuitGame();
        }
    }

    public void PlayTimeTrial()
    {
        playerInputActions.Menu.Disable();

        optionSelected = 0;
        SceneManager.LoadScene("TimeTrial");
    }

    public void GoToMultiplayer()
    {
        playerInputActions.Menu.Disable();

        mainMenu.SetActive(false);    // Disables the main menu
        multiplayerCanvas.SetActive(true);  // Enables the canvas, which connects to the server
        multiplayerMenu.SetActive(true);    // Enables the multiplayer menu
    }

    public void GoToSettings()
    {
        playerInputActions.Menu.Disable();

        mainMenu.SetActive(false);    // Disables the main menu
        optionsMenu.SetActive(true);    // Enables the options menu
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}