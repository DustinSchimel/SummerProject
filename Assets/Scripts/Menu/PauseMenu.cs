using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    private PlayerInputActions playerInputActions;
    public PlayerController playerController;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public Button resumeButton;
    public Button settingsButton;
    public Button menuButton;
    public Button quitButton;

    [Header("Values")]
    private int optionSelected;

    public void OnEnable()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.PauseMenu.Enable();
        playerInputActions.PauseMenu.MoveUp.performed += MoveUp;
        playerInputActions.PauseMenu.MoveDown.performed += MoveDown;
        playerInputActions.PauseMenu.SelectOption.performed += SelectOption;
        playerInputActions.PauseMenu.Resume.performed += Resume;

        optionSelected = 0;
        resumeButton.Select();
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Resume Button' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 1)   // 'Settings Button' is selected
        {
            // Enable 'Resume Button' selection
            resumeButton.Select();

            optionSelected = 0;
        }
        else if (optionSelected == 2)   // 'Menu Button' is selected
        {
            // Enable 'Settings Button' selection
            settingsButton.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 3)   // 'Quit Button' is selected
        {
            // Enable 'Menu Button' selection
            menuButton.Select();

            optionSelected = 2;
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Resume Button' is selected
        {
            // Enable 'Settings Button' selection
            settingsButton.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 1)    // 'Settings Button' is selected
        {
            // Enable 'Menu Button' selection
            menuButton.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)    // 'Menu Button' is selected
        {
            // Enable 'Quit Button' selection
            quitButton.Select();

            optionSelected = 3;
        }
        else if (optionSelected == 3)    // 'Quit Button' is selected
        {
            // Do nothing
        }
    }

    public void SelectOption(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Resume Button' is selected
        {
            Resume();
        }
        else if (optionSelected == 1)   // 'Settings Button' is selected
        {
            playerInputActions.PauseMenu.Disable();
            optionsMenu.SetActive(true);    // Enables the options menu
            pauseMenu.SetActive(false);    // Disables the pause menu
        }
        else if (optionSelected == 2)   // 'Menu Button' is selected
        {
            playerInputActions.PauseMenu.Disable();
            SceneManager.LoadScene(0);
        }
        else if (optionSelected == 3)   // 'Quit Button' is selected
        {
            Application.Quit();
        }
    }

    public void Resume(InputAction.CallbackContext context)
    {
        playerInputActions.PauseMenu.Disable();
        playerController.EnableControls();
        pauseMenu.SetActive(false);
    }

    public void Resume()
    {
        playerInputActions.PauseMenu.Disable();
        playerController.EnableControls();
        pauseMenu.SetActive(false);
    }
}
