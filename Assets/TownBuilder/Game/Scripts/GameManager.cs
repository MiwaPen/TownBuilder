using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RepositoryBase repositoryBase;
    [SerializeField] private ParentScript parentScript;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AudioController audioController;
    [SerializeField] private int _MaxHP = 0;
    private int HP = 0;
    private PlayerScore playerScore;
    private int _playerCurrentScore;
    private int _playerMaxScore;

    public Action ResetSceneEvent;
    public Action OnGameStart;
    public Action OnLose;
    public Action MainMenuEvent;

    public Action OnHPChangeEvent;
    public Action OnScoreChangeEvent;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        playerScore = repositoryBase.PlayerScore;
        _playerCurrentScore = playerScore._currentScore;
        _playerMaxScore = playerScore._maxScore;
        playerScore.UpdateCurrentScoreInfo += UpdateCurrScore;
        parentScript.IncreesScore += UpdateReposCurrScore;
        MainMenu();
        audioController.Music();
    }

    public void Startgame()
    {
        ResetScene();
        HP = _MaxHP;
        playerController.AccessSpawnTrue();
        OnGameStart?.Invoke();
        audioController.Click();
    }

    public void MainMenu()
    {
        audioController.Click();
        ResetScene();
        playerController.AccessSpawnFalse();
        HP = 0;
        _playerMaxScore = playerScore._maxScore;
        MainMenuEvent?.Invoke();
    }

    public void Lose()
    {
        SaveMaxScore(_playerCurrentScore);
        playerController.AccessSpawnFalse();
        OnLose?.Invoke();
        audioController.endGame();
    }

    public void UpdateHP()
    {
        HP -= 1;
        if (HP <= 0)
        {
            Lose();
        }
        OnHPChangeEvent?.Invoke();
    }

    private void ResetScene()
    {
        ResetSceneEvent?.Invoke();
    } 

    void UpdateCurrScore()
    {
        _playerCurrentScore = playerScore._currentScore;
        OnScoreChangeEvent?.Invoke();
    }

    public int GetCurrentHP()
    {
        return HP;
    }
    public int GetCurrScore()
    {
        return _playerCurrentScore;
    }
    public int GetMaxScore()
    {
        return _playerMaxScore;
    }

    void UpdateReposCurrScore()
    {
        _playerCurrentScore = parentScript.GetChildrenCount();
        playerScore.UpdateCurrentScore(_playerCurrentScore);
    }

    void SaveMaxScore(int currentResult)
    {
        playerScore.SaveMaxScore(currentResult);
    }

    public void ExitGame()
    {
        audioController.Click();
        Application.Quit();
    }
}
