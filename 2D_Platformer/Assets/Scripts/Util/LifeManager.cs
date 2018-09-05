using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LifeManager : MonoBehaviour
{
    private int lifeCounter;

    [SerializeField]
    private Text lifeText;

	void Start ()
    {
        lifeCounter = PlayerPrefs.GetInt("Lives");
	}

	void Update ()
    {
        lifeText.text = lifeCounter.ToString();
	}

    public void TakeOneLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("Lives", lifeCounter);
    }

    public int GetLifeCounter()
    {
        return lifeCounter;
    }

    public void ResetLivesCount()
    {
        lifeCounter = 3;
        PlayerPrefs.SetInt("Lives", lifeCounter);
    }
}