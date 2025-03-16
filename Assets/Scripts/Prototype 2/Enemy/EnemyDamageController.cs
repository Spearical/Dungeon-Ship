using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageController : MonoBehaviour, IDamageable
{
    public bool isInvincible = false;
    private IHealth health;
    private EnemyInvincibilityController invincibilityController;
    public UnityEvent onHealthZero;
    public UnityEvent onDamageTaken;
    [SerializeField]
    private float invincibilityDuration = 1.5f;
    [SerializeField]
    private Color flashColor = Color.white;
    [SerializeField]
    private int numberOfFlashes = 2;

    private void Awake()
    {
        health = GetComponent<IHealth>();
        invincibilityController = GetComponent<EnemyInvincibilityController>();
    }

    public void DealDamage(float damageAmount)
    {
        if (!isInvincible)
        {
            onDamageTaken.Invoke();
            health.ChangeHealth(damageAmount);
            CheckIfEnemyHasZeroHealth();
        }
    }
    private void CheckIfEnemyHasZeroHealth()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            onHealthZero.Invoke();  
        }
        else
        {
            invincibilityController.StartInvincibility(invincibilityDuration, flashColor, numberOfFlashes);
        }
    }
}
