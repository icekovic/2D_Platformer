using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    [SerializeField]
    private GameObject levelCompleted;

    private LevelTransition levelTransition;

    void Start()
    {
        levelCompleted.SetActive(false);

        levelTransition = FindObjectOfType<LevelTransition>();
    }

    void Update()
    {

    }

    public void NextLevel()
    {
        //ako je prvi level prijeđen, loadaj drugi level/scenu
        if(levelTransition.GetFirstLevelPassed())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("SecondLevel");
        }

        //ako je drugi level prijeđen, loadaj treći level/scenu
        else if (levelTransition.GetSecondLevelPassed())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("ThirdLevel");
        }
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

    public GameObject GetLevelCompletedCanvas()
    {
        Time.timeScale = 0f;
        return levelCompleted;
    }
}
