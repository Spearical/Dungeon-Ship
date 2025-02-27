using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerDamageController : MonoBehaviour, IDamageable
{
    public bool isInvincible = false;
    public UnityEvent onHealthZero;
    private PlayerHealth health;
    private InvincibilityController invincibilityController;
    private PlayerController playerController;
    [SerializeField]
    private float invincibilityDuration = 3.0f;
    [SerializeField]
    private Color flashColor = Color.white;
    [SerializeField]
    private int numberOfFlashes = 3;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        invincibilityController = GetComponent<InvincibilityController>();
        health = GetComponent<PlayerHealth>();
    }

    public void DealDamage(float damageAmount)
    {
        if (!isInvincible && !playerController.IsShieldActive())
        {
            health.ChangePlayerHealth(damageAmount);
            CheckIfPlayerHasZeroHealth();
            invincibilityController.StartInvincibility(invincibilityDuration, flashColor, numberOfFlashes);
        }
    }
    private void CheckIfPlayerHasZeroHealth()
    {
        if (health.GetCurrentPlayerHealth() <= 0)
        {
            onHealthZero.Invoke();
        }    
    }
}
