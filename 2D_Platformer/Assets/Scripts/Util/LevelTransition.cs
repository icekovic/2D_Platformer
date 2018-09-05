using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    private bool firstLevelPassed;
    private bool secondLevelPassed;

    void Start()
    {
        firstLevelPassed = false;
        secondLevelPassed = false;
    }

    public bool GetFirstLevelPassed()
    {
        return firstLevelPassed;
    }

    public bool GetSecondLevelPassed()
    {
        return secondLevelPassed;
    }

    public void FirstLevelIsPassed()
    {
        firstLevelPassed = true;
    }

    public void SecondLevelIsPassed()
    {
        secondLevelPassed = true;
    }
}