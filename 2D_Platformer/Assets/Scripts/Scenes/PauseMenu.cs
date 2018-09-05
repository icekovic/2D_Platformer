using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool isPaused = false;

    [SerializeField]
    private GameObject pauseMenu;

    private CollectiblesManager collectiblesManager;

    void Start ()
    {
        pauseMenu.SetActive(false);
        collectiblesManager = FindObjectOfType<CollectiblesManager>();
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;    //default game state
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        collectiblesManager.ResetCoinsCount();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;    //stops the game
        isPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}