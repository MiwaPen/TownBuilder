using UnityEngine;
using TMPro;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScoreLabel;
    [SerializeField] private TMP_Text _currentHPLabel;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gameManager.OnHPChangeEvent += UpdateHP;
        gameManager.OnScoreChangeEvent += UpdateScore;
        gameManager.OnGameStart += SetStartInfo;
    }

    private void SetStartInfo()
    {
        UpdateHP();
        UpdateScore();
    }

    private void UpdateHP()
    {
        int hp = gameManager.GetCurrentHP();
        _currentHPLabel.text = "HP:" + hp;
    }

    private void UpdateScore()
    {
        int score = gameManager.GetCurrScore();
        _currentScoreLabel.text = score.ToString();
    }
}

