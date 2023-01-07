using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject multiplayerCanvas;

    [SerializeField] private Button singleplayerButton;

    public void OnEnable()
    {
        singleplayerButton.Select();
    }

    public void GoToMultiplayer()
    {
        mainMenu.SetActive(false);    // Disables the main menu
        multiplayerCanvas.SetActive(true);  // Enables the canvas, which connects to the server
    }

    public void GoToSingleplayer()
    {
        SceneManager.LoadScene("timetrial", LoadSceneMode.Single);
    }

    public void GoToSettings()
    {
        mainMenu.SetActive(false);    // Disables the main menu
        optionsMenu.SetActive(true);    // Enables the options menu
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}