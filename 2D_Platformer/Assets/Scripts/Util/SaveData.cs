using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private LifeManager lifeManager;
    private CollectiblesManager collectiblesManager;

    private int totalCoinsPoints = 0;
    private int totalScore = 0;

    string path = "Score/score.txt";

    void Start ()
    {
        lifeManager = FindObjectOfType<LifeManager>();
        collectiblesManager = FindObjectOfType<CollectiblesManager>();
	}

    public void SavePlayerScore()
    {
        totalCoinsPoints = collectiblesManager.GetCoinsCounter() * ItemsValues.coinValue;
        totalScore = totalCoinsPoints + ItemsValues.blueJewelValue + ItemsValues.greenJewelValue + ItemsValues.redJewelValue;

        if(!File.Exists(path))
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine("SCORE");
                writer.WriteLine("--------------------------------");

                WriteData(writer, "Coins collected: ", collectiblesManager.GetCoinsCounter());
                WriteData(writer, "Lives left: ", lifeManager.GetLifeCounter());
                WriteData(writer, "Number of blue jewels: " , collectiblesManager.GetBlueJewelCounter());
                WriteData(writer, "Number of green jewels: ", collectiblesManager.GetGreenJewelCounter());
                WriteData(writer, "Number of red jewels: ", collectiblesManager.GetRedJewelCounter());

                writer.WriteLine("--------------------------------");

                WriteData(writer, "Coin points (amount * value): ", totalCoinsPoints);
                WriteData(writer, "Blue jewels points: ", ItemsValues.blueJewelValue);
                WriteData(writer, "Green jewels points: ", ItemsValues.greenJewelValue);
                WriteData(writer, "Red jewels points: ", ItemsValues.redJewelValue);

                writer.WriteLine("--------------------------------");

                WriteData(writer, "Total score: ", totalScore);

                writer.WriteLine("=================================");

            }
        }
    }

    private void WriteData(StreamWriter writer, string valueName, int value)
    {
        writer.WriteLine(valueName + value);
    }
}