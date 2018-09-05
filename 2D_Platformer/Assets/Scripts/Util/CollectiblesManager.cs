using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CollectiblesManager : MonoBehaviour
{
    [SerializeField]
    private Text coinsText;
    private int coinsCounter;

    [SerializeField]
    private Text blueJewelText;
    private int blueJewelCounter;

    [SerializeField]
    private Text greenJewelText;
    private int greenJewelCounter;

    [SerializeField]
    private Text redJewelText;
    private int redJewelCounter;

    void Start ()
    {
        coinsCounter = PlayerPrefs.GetInt("Coins");
        blueJewelCounter = PlayerPrefs.GetInt("BlueJewel");
        greenJewelCounter = PlayerPrefs.GetInt("GreenJewel");
        redJewelCounter = PlayerPrefs.GetInt("RedJewel");
    }

    void Update ()
    {
        coinsText.text = coinsCounter.ToString();
        blueJewelText.text = blueJewelCounter.ToString();
        greenJewelText.text = greenJewelCounter.ToString();
        redJewelText.text = redJewelCounter.ToString();

    }

    public void IncreaseCoinsCounter()
    {
        coinsCounter++;
        PlayerPrefs.SetInt("Coins", coinsCounter);
    }

    public void IncreaseBlueJewelCounter()
    {
        blueJewelCounter++;
        PlayerPrefs.SetInt("BlueJewel", blueJewelCounter);
    }

    public void IncreaseGreenJewelCounter()
    {
        greenJewelCounter++;
        PlayerPrefs.SetInt("GreenJewel", greenJewelCounter);
    }

    public void IncreaseRedJewelCounter()
    {
        redJewelCounter++;
        PlayerPrefs.SetInt("RedJewel", redJewelCounter);
    }

    public void ResetCoinsCount()
    {
        coinsCounter = 0;
        PlayerPrefs.SetInt("Coins", coinsCounter);
    }
    public void ResetGreenJewelCounter()
    {
        blueJewelCounter = 0;
        PlayerPrefs.SetInt("BlueJewel", blueJewelCounter);
    }

    public void ResetRedJewelCounter()
    {
        greenJewelCounter = 0;
        PlayerPrefs.SetInt("GreenJewel", greenJewelCounter);
    }

    public void ResetBlueJewelCounter()
    {
        redJewelCounter = 0;
        PlayerPrefs.SetInt("RedJewel", redJewelCounter);
    }

    public int GetCoinsCounter()
    {
        return coinsCounter;
    }

    public int GetBlueJewelCounter()
    {
        return blueJewelCounter;
    }

    public int GetGreenJewelCounter()
    {
        return greenJewelCounter;
    }

    public int GetRedJewelCounter()
    {
        return redJewelCounter;
    }
}