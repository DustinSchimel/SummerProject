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

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.OptionsScreen.Enable();
        playerInputActions.OptionsScreen.MoveUp.performed += MoveUp;
        playerInputActions.OptionsScreen.MoveDown.performed += MoveDown;
        playerInputActions.OptionsScreen.SelectOption.performed += SelectOption;
        playerInputActions.OptionsScreen.VolumeUp.performed += VolumeUp;
        playerInputActions.OptionsScreen.VolumeDown.performed += VolumeDown;

        if(Screen.fullScreen == true)
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
        }
        else
        {
            savedSfxVolume = sfxSlider.value;
            savedMusicVolume = musicSlider.value;
        }

        sfxSlider.value = savedSfxVolume;
        musicSlider.value = savedMusicVolume;

        if (SceneManager.GetActiveScene().buildIndex != 0)  // If the scene is not the title screen, freeze time
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
            // Do nothing
        }
        else if (optionSelected == 1)   // 'Music Volume' is selected
        {
            // Enable 'Sfx Volume' selection
            sfxSlider.Select();

            optionSelected = 0;
        }
        else if (optionSelected == 2)   // 'Fullscreen Toggle' is selected
        {
            // Enable 'Music Volume' selection
            musicSlider.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 3)   // 'Back Button' is selected
        {
            // Enable 'Fullsceen Toggle' selection
            fullScreenToggle.Select();

            optionSelected = 2;
        }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (optionSelected == 0)    // 'Sfx Volume' is selected
        {
            // Enable 'Music Volume' selection
            musicSlider.Select();

            optionSelected = 1;
        }
        else if (optionSelected == 1)    // 'Music Volume' is selected
        {
            // Enable 'Fullscreen toggle' selection
            fullScreenToggle.Select();

            optionSelected = 2;
        }
        else if (optionSelected == 2)    // 'Fullscreen Toggle' is selected
        {
            // Enable 'Back' selection
            backButton.Select();

            optionSelected = 3;
        }
        else if (optionSelected == 3)    // 'Back Button' is selected
        {
            // Do nothing
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
            if (fullScreenToggle.isOn)
            {
                fullScreenToggle.isOn = false;
            }
            else
            {
                fullScreenToggle.isOn = true;
            }
        }
        else if (optionSelected == 3)   // 'Back Button' is selected
        {
            playerInputActions.OptionsScreen.Disable();
            mainMenu.SetActive(true);    // Enables the main menu
            optionsMenu.SetActive(false);    // Disables the options menu
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

    public void OnDisable()
    {
        playerInputActions.OptionsScreen.Disable();

        // Save volume
        PlayerPrefs.SetFloat("sfxVolume", savedSfxVolume);
        PlayerPrefs.SetFloat("musicVolume", savedMusicVolume);
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
}