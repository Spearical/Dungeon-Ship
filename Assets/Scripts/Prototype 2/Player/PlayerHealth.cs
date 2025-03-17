using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;
    private GameManager gameManager;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    public void ChangeHealth(float amountToChange)
    {
        currentHealth += amountToChange;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void GameOverOnZeroHealth()
    {
        gameManager.SetGameState(GameState.GameOver);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
