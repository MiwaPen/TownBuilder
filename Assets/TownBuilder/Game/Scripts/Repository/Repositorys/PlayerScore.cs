using UnityEngine;
using System;

public class PlayerScore 
{
    public Action UpdateMaxScoreInfo;
    public Action UpdateCurrentScoreInfo;
    const string maxScoreKey = "maxScoreKey";
    public int _currentScore { get; set; }
    public int _maxScore { get; set; }

    public void Initialize()
    {
        _currentScore = 0;
        _maxScore = PlayerPrefs.GetInt(maxScoreKey);
    }

    public void UpdateCurrentScore(int currentResult)
    {
        _currentScore = currentResult;
        UpdateCurrentScoreInfo?.Invoke();
    }
    
    public void SaveMaxScore(int currentResult)
    {
        if (currentResult > _maxScore)
        {
            PlayerPrefs.SetInt(maxScoreKey,currentResult);
            UpdateMaxScoreInfo?.Invoke();
        }
    }
}
