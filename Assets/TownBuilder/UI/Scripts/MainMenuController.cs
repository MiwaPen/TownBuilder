using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button StartBTN;
    [SerializeField] private Button ExitBTN;
    [SerializeField] private TMP_Text _maxScoreLabel;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        StartBTN.onClick.AddListener(gameManager.Startgame);
        ExitBTN.onClick.AddListener(gameManager.ExitGame);
        gameManager.MainMenuEvent += SetMaxScoreLabel;
    }

    private void SetMaxScoreLabel()
    {
        int maxScore = gameManager.GetMaxScore();
        _maxScoreLabel.text = "Max:" + maxScore;
    }
}
