using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] RepositoryBase repositoryBase;
    [SerializeField] ParentScript parentScript;
    private PlayerScore playerScore;
    private int _playerCurrentScore;
    private void Awake()
    {
        Application.targetFrameRate = 120;

        playerScore = repositoryBase.PlayerScore;
        _playerCurrentScore = playerScore._currentScore;
        playerScore.UpdateCurrentScoreInfo += UpdateCurrScore;
        parentScript.IncreesScore += UpdateReposCurrScore;
    }

    void Startgame()
    {

    }

    void UpdateCurrScore()
    {
        _playerCurrentScore = playerScore._currentScore;
    }

    void UpdateReposCurrScore()
    {
        _playerCurrentScore = parentScript.GetChildrenCount();
        playerScore.UpdateCurrentScore(_playerCurrentScore);
        Debug.Log(_playerCurrentScore);
    }

    void SaveMaxScore(int currentResult)
    {
        playerScore.SaveMaxScore(currentResult);
    }

}
