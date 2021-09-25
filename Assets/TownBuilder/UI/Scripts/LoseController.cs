using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseController : MonoBehaviour
{
    [SerializeField] private Button RetryBTN;
    [SerializeField] private Button MenuBTN;
    [SerializeField] private TMP_Text _currentScoreLabel;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        RetryBTN.onClick.AddListener(gameManager.Startgame);
        MenuBTN.onClick.AddListener(gameManager.MainMenu);
        gameManager.OnLose += SetScoreLabel;
        SetScoreLabel();
    }

    private void SetScoreLabel()
    {
        int maxScore = gameManager.GetCurrScore();
        _currentScoreLabel.text = "Score:" + maxScore;
    }
}
