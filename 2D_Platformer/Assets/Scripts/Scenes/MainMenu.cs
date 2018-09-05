using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int livesCounter;

    [SerializeField]
    private int coinsCounter;

    [SerializeField]
    private int blueJewelCounter;

    [SerializeField]
    private int greenJewelCounter;

    [SerializeField]
    private int redJewelCounter;

    void Start()
    {

    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Lives", livesCounter);
        PlayerPrefs.SetInt("Coins", coinsCounter);
        PlayerPrefs.SetInt("BlueJewel", blueJewelCounter);
        PlayerPrefs.SetInt("GreenJewel", greenJewelCounter);
        PlayerPrefs.SetInt("RedJewel", redJewelCounter);

        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstLevel");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game...");
        Application.Quit();
    }
}