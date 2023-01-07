using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SPPauseMenu : PauseMenu
{
    public override void Resume()
    {
        ((SPStats)stats).isPaused = false;
        playerInputActions.Player.Enable();

        pauseMenu.SetActive(false);
    }

    public override void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public override void QuitGame()
    {
        Application.Quit();
    }
}