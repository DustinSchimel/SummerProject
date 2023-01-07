using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class MPPauseMenu : PauseMenu
{
    public override void Resume()
    {
        ((MPStats)stats).isPaused = false;
        playerInputActions.Player.Enable();

        joinCodeField.enabled = true;
        playerCountField.enabled = true;
        pauseMenu.SetActive(false);
    }

    public override void LoadMainMenu()
    {
        NetworkManager.Singleton.Shutdown();

        SceneManager.LoadScene("Menu");
    }

    public override void QuitGame()
    {
        NetworkManager.Singleton.Shutdown();

        Application.Quit();
    }
}