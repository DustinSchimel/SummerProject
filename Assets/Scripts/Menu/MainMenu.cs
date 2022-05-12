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

    public Button timeTrialButton;
    public Button multiplayerButton;
    public Button settingsButton;
    public Button quitButton;

    [Header("Values")]
    private int optionSelected;

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.TitleScreen.Enable();
        playerInputActions.TitleScreen.MoveUp.performed += MoveUp;
        playerInputActions.TitleScreen.MoveDown.performed += MoveDown;
        playerInputActions.TitleScreen.SelectOption.performed += SelectOption;

        optionSelected = 0;
        timeTrialButton.Select();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Time Trial' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 1)   // 'Multiplayer' is selected
        {
            // Enable 'Time Trial' selection
            timeTrialButton.Select();

            optionSelected = 0;
        }
        else if (optionSelected == 2)   // 'Settings' is selected
        {
            // Enable 'Multiplayer' selection
            multiplayerButton.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 3)   // 'Quit' is selected
        {
            // Enable 'Settings' selection
            settingsButton.Select();

            optionSelected = 2;
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Time Trial' is selected
        {
            // Enable 'Multiplayer' selection
            multiplayerButton.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 1)    // 'Multiplayer' is selected
        {
            // Enable 'Settings' selection
            settingsButton.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)    // 'Settings' is selected
        {
            // Enable 'Quit' selection
            quitButton.Select();

            optionSelected = 3;
        }
        else if (optionSelected == 3)    // 'Quit' is selected
        {
            // Do nothing
        }
    }

    public void SelectOption(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Time Trial' is selected
        {
            playerInputActions.TitleScreen.Disable();
            optionSelected = 0;
            PlayGame();
        }
        else if (optionSelected == 1)   // 'Multiplayer' is selected
        {
            playerInputActions.TitleScreen.Disable();
            multiplayerMenu.SetActive(true);    // Enables the multiplayer menu
            mainMenu.SetActive(false);    // Disables the main menu
        }
        else if (optionSelected == 2)   // 'Settings' is selected
        {
            playerInputActions.TitleScreen.Disable();
            optionsMenu.SetActive(true);    // Enables the options menu
            mainMenu.SetActive(false);    // Disables the main menu
        }
        else if (optionSelected == 3)   // 'Quit' is selected
        {
            QuitGame();
        }
    }

    public void OnDisable()
    {
        optionSelected = 0;
        playerInputActions.TitleScreen.Disable();
    }
}
