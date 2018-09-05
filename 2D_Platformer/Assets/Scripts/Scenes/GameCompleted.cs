using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleted : MonoBehaviour
{
    [SerializeField]
    private GameObject gameCompleted;

    void Start ()
    {
        gameCompleted.SetActive(false);
	}
	void Update ()
    {
		
	}

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }

    public GameObject GetGameCompletedCanvas()
    {
        Time.timeScale = 0f;
        return gameCompleted;
    }
}