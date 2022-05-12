using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("References")]
    private PlayerInputActions playerInputActions;
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public Slider sfxSlider;
    public Slider musicSlider;
    public Toggle fullScreenToggle;
    public Button backButton;

    [Header("Values")]
    private int optionSelected;
    public float volumeSliderValue = .2f;
    private float savedSfxVolume;
    private float savedMusicVolume;

    // Add saving of player colors here possibly

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Menu.Enable();
        playerInputActions.Menu.MoveUp.performed += MoveUp;
        playerInputActions.Menu.MoveDown.performed += MoveDown;
        playerInputActions.Menu.SelectOption.performed += SelectOption;
        playerInputActions.Menu.VolumeUp.performed += VolumeUp;
        playerInputActions.Menu.VolumeDown.performed += VolumeDown;

        if (Screen.fullScreen == true)
        {
            fullScreenToggle.isOn = true;
        }
        else if (Screen.fullScreen == false)
        {
            fullScreenToggle.isOn = false;
        }

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            savedSfxVolume = PlayerPrefs.GetFloat("sfxVolume");
            savedMusicVolume = PlayerPrefs.GetFloat("musicVolume");

            sfxSlider.value = savedSfxVolume;
            musicSlider.value = savedMusicVolume;
        }
        else
        {
            savedSfxVolume = sfxSlider.value;
            savedMusicVolume = musicSlider.value;
        }

        if (SceneManager.GetActiveScene().name != "Menu")  // If the scene is not the title screen, freeze time
        {
            Time.timeScale = 0f;
        }

        optionSelected = 0;
        sfxSlider.Select();
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Sfx Volume' is selected
        {
            sfxSlider.Select();
        }
        else if (optionSelected == 1)   // 'Music Volume' is selected
        {
            sfxSlider.Select();

            optionSelected = 0;
        }
        else if (optionSelected == 2)   // 'Fullscreen Toggle' is selected
        {
            musicSlider.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 3)   // 'Back Button' is selected
        {
            fullScreenToggle.Select();

            optionSelected = 2;
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Sfx Volume' is selected
        {
            musicSlider.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 1)    // 'Music Volume' is selected
        {
            fullScreenToggle.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)    // 'Fullscreen Toggle' is selected
        {
            backButton.Select();

            optionSelected = 3;
        }
        else if (optionSelected == 3)    // 'Back Button' is selected
        {
            backButton.Select();
        }
    }

    public void SelectOption(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Sfx Volume' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 1)   // 'Music Volume' is selected
        {
            // Do nothing
        }
        else if (optionSelected == 2)   // 'Fullscreen Toggle' is selected
        {
            ToggleFullscreen(Screen.fullScreen);
        }
        else if (optionSelected == 3)   // 'Back Button' is selected
        {
            GoBack();
        }
    }

    public void VolumeDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)
        {
            sfxSlider.value = sfxSlider.value - volumeSliderValue;
        }
        else if (optionSelected == 1)
        {
            musicSlider.value = musicSlider.value - volumeSliderValue;
        }
    }

    public void VolumeUp(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)
        {
            sfxSlider.value = sfxSlider.value + volumeSliderValue;
        }
        else if (optionSelected == 1)
        {
            musicSlider.value = musicSlider.value + volumeSliderValue;
        }
    }

    public void SetSfxVolume(float volume)
    {
        savedSfxVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        savedMusicVolume = volume;
    }

    public void ToggleFullscreen(bool value)
    {
        if (value)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    public void GoBack()
    {
        // Save volume
        PlayerPrefs.SetFloat("sfxVolume", savedSfxVolume);
        PlayerPrefs.SetFloat("musicVolume", savedMusicVolume);

        playerInputActions.Menu.Disable();

        optionsMenu.SetActive(false);    // Disables the options menu
        mainMenu.SetActive(true);    // Enables the main menu
    }
}