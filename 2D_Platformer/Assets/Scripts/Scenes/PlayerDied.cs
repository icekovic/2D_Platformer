using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    [SerializeField]
    private GameObject playerDied;

    private CollectiblesManager collectiblesManager;

    void Start ()
    {
        playerDied.SetActive(false);
        collectiblesManager = FindObjectOfType<CollectiblesManager>();
    }

	void Update ()
    {
		
	}

    public void Restart()
    {
        Time.timeScale = 1f;
        collectiblesManager.ResetCoinsCount();
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

    public GameObject GetPlayerDiedCanvas()
    {
        Time.timeScale = 0f;
        return playerDied;
    }
}