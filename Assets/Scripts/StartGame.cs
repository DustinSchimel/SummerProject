using UnityEngine;
using UnityEngine.SceneManagement;

// This script and scene is needed so that the scene which
// creates the NetworkManager is not ever accessed twice

public class StartGame : MonoBehaviour
{
    [SerializeField] private PlayersManager playersManager;

    void Start()
    {
        DontDestroyOnLoad(playersManager);
        SceneManager.LoadScene("Menu");
    }
}