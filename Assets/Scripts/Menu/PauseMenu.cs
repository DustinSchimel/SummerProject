using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    private PlayerInputActions playerInputActions;
    public PlayerController playerController;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

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
        //playerInputActions.Menu.Disable();
        //playerController.EnableControls();
        playerInputActions.Player.Enable();
        pauseMenu.SetActive(false);
        joinCodeField.enabled = true;
        playerCountField.enabled = true;
    }

    public void LoadMainMenu()
    {
        //playerInputActions.Menu.Disable();
        //NetworkManager.Singleton.DisconnectClient;
        NetworkManager.Singleton.Shutdown();
        //NetworkManager.Singleton.Shutdown

        //while (NetworkManager.Singleton != null)
        //{
        //    Destroy(NetworkManager.Singleton.gameObject);
        //}

        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
