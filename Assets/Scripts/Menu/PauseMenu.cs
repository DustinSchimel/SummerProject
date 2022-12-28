using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    private PlayerInputActions playerInputActions;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private Button resumeButton;

    [SerializeField] private TMP_Text joinCodeField;
    [SerializeField] private TMP_Text playerCountField;

    public void Pause(PlayerInputActions playerInputActions)
    {
        this.playerInputActions = playerInputActions;
        playerInputActions.Player.Disable();

        joinCodeField.enabled = false;
        playerCountField.enabled = false;
        pauseMenu.SetActive(true);

        resumeButton.Select();
    }
    public void Resume()
    {
        playerInputActions.Player.Enable();

        joinCodeField.enabled = true;
        playerCountField.enabled = true;
        pauseMenu.SetActive(false);
    }

    public void LoadMainMenu()
    {
        NetworkManager.Singleton.Shutdown();

        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        NetworkManager.Singleton.Shutdown();

        Application.Quit();
    }

    public void LoadOptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void DeloadOptionsMenu()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);

        resumeButton.Select();
    }
}
