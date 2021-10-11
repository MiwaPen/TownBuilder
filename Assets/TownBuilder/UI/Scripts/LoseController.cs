using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseController : MonoBehaviour
{
    [SerializeField] private Button RetryBTN;
    [SerializeField] private Button MenuBTN;
    [SerializeField] private TMP_Text _currentScoreLabel;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioController audioController;

    private void Awake()
    {
        RetryBTN.onClick.AddListener(StartBtnFunc);
        MenuBTN.onClick.AddListener(BackToMain);
        gameManager.OnLose += SetScoreLabel;
        SetScoreLabel();
    }

    private void StartBtnFunc()
    {
        audioController.Click();
        gameManager.Startgame();
    }

    private void BackToMain()
    {
        audioController.Click();
        gameManager.MainMenu();
    }

    private void SetScoreLabel()
    {
        int maxScore = gameManager.GetCurrScore();
        _currentScoreLabel.text = "Score:" + maxScore;
    }
}
