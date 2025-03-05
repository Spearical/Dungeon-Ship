using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    private GameManager gameManager;

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void ChangePlayerHealth(float amountToChange)
    {
        health += amountToChange;
    }

    public float GetCurrentPlayerHealth()
    {
        return health;
    }

    public void GameOverOnZeroHealth()
    {
        gameManager.SetGameState(GameState.GameOver);
    }
}
