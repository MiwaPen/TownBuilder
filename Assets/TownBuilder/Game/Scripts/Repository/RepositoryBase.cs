using UnityEngine;

public class RepositoryBase : MonoBehaviour
{
    private PlayerScore playerScore = new PlayerScore();
    public PlayerScore PlayerScore { get => playerScore; }
   
    private void Awake()
    {
        playerScore.Initialize();
    }
}
