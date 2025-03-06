using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerDamageController : MonoBehaviour, IDamageable
{
    public bool isInvincible = false;
    private IHealth health;
    private InvincibilityController invincibilityController;
    private PlayerController playerController;
    [SerializeField]
    private float invincibilityDuration = 3.0f;
    [SerializeField]
    private Color flashColor = Color.white;
    [SerializeField]
    private int numberOfFlashes = 3;
    public UnityEvent onHealthZero;
    public UnityEvent onDamageTaken;
    public Slider healthSlider;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        invincibilityController = GetComponent<InvincibilityController>();
        health = GetComponent<IHealth>();
    }

    private void Start()
    {
        healthSlider.maxValue = health.GetMaxHealth();
        healthSlider.value = health.GetCurrentHealth();
    }

    public void DealDamage(float damageAmount)
    {
        if (!isInvincible && !playerController.IsShieldActive())
        {
            onDamageTaken.Invoke();
            health.ChangeHealth(damageAmount);
            healthSlider.value = health.GetCurrentHealth();
            CheckIfPlayerHasZeroHealth();
            invincibilityController.StartInvincibility(invincibilityDuration, flashColor, numberOfFlashes);
        }
    }
    private void CheckIfPlayerHasZeroHealth()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            onHealthZero.Invoke();
        }    
    }
}
