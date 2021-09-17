using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuScreen;
    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private GameObject IngameUI;

    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        MainMenuScreen.SetActive(false);
        LoseScreen.SetActive(false);
        IngameUI.SetActive(false);
        gameManager.OnGameStart += PlayerUI;
        gameManager.OnLose += Lose;
        gameManager.MainMenuEvent += MainMenu;
    }

    private void MainMenu()
    {
        MainMenuScreen.SetActive(true);
        LoseScreen.SetActive(false);
        IngameUI.SetActive(false);
    }

    private void Lose()
    {
        MainMenuScreen.SetActive(false);
        LoseScreen.SetActive(true);
        IngameUI.SetActive(false);
    }

    private void PlayerUI()
    {
        MainMenuScreen.SetActive(false);
        LoseScreen.SetActive(false);
        IngameUI.SetActive(true);
    }
}
