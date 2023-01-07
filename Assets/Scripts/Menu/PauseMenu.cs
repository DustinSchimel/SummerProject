using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public abstract class PauseMenu : MonoBehaviour
{
    [Header("References")]
    protected PlayerInputActions playerInputActions;
    protected MonoBehaviour stats;
    [SerializeField] protected GameObject optionsMenu;
    [SerializeField] protected GameObject pauseMenu;

    [SerializeField] protected Button resumeButton;

    [SerializeField] protected TMP_Text joinCodeField;
    [SerializeField] protected TMP_Text playerCountField;

    public void Pause(PlayerInputActions playerInputActions, SPStats stats)
    {
        this.playerInputActions = playerInputActions;
        playerInputActions.Player.Disable();

        this.stats = stats;
        stats.isPaused = true;

        pauseMenu.SetActive(true);

        resumeButton.Select();
    }

    public void Pause(PlayerInputActions playerInputActions, MPStats stats)
    {
        this.playerInputActions = playerInputActions;
        playerInputActions.Player.Disable();

        this.stats = stats;
        stats.isPaused = true;

        joinCodeField.enabled = false;
        playerCountField.enabled = false;
        pauseMenu.SetActive(true);

        resumeButton.Select();
    }

    public abstract void Resume();

    public abstract void LoadMainMenu();

    public abstract void QuitGame();

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
