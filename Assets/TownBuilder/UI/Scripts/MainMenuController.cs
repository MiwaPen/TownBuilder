using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button StartBTN;
    [SerializeField] private Button ExitBTN;
    [SerializeField] private TMP_Text _maxScoreLabel;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioController audioController;

    private void Awake()
    {
        StartBTN.onClick.AddListener(StartBtnFunc);
        ExitBTN.onClick.AddListener(ExirBtnFunc);
        gameManager.MainMenuEvent += SetMaxScoreLabel;
        SetMaxScoreLabel();
    }

    private void StartBtnFunc()
    {
        audioController.Click();
        gameManager.Startgame();
    }

    private void ExirBtnFunc()
    {
        audioController.Click();
        gameManager.ExitGame();
    }

    private void SetMaxScoreLabel()
    {
        int maxScore = gameManager.GetMaxScore();
        _maxScoreLabel.text = "Max:" + maxScore;
    }
}
