using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;

    private LifeManager lifeManager;
    private CollectiblesManager collectiblesManager;

    void Start ()
    {
        gameOver.SetActive(false);
        lifeManager = FindObjectOfType<LifeManager>();
        collectiblesManager = FindObjectOfType<CollectiblesManager>();
    }

	void Update ()
    {
		
	}

    public void Restart()
    {
        Time.timeScale = 1f;

        lifeManager.ResetLivesCount();
        collectiblesManager.ResetCoinsCount();
        collectiblesManager.ResetBlueJewelCounter();
        collectiblesManager.ResetGreenJewelCounter();
        collectiblesManager.ResetRedJewelCounter();

        SceneManager.LoadScene("FirstLevel");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }

    public GameObject GetGameOverCanvas()
    {
        return gameOver;
    }
}