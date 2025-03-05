using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    public int brickScore;
    public PowerUpType powerUpType;
    private GameManager gameManager;

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void SendBrickScoreToGameManager()
    {
        gameManager.UpdateScore(brickScore);
    }
}
