using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle fullScreenToggle;

    [Header("Values")]
    private float savedSfxVolume;
    private float savedMusicVolume;

    // Add saving of player colors here possibly

    public void OnEnable()  // Called when the object this script is attatched to gets enabled
    {
        sfxSlider.Select();

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

        gameObject.SetActive(false);    // Disables the options menu
        mainMenu.SetActive(true);    // Enables the main menu
    }
}