using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerDamageController : MonoBehaviour, IDamageable, IHealable
{
    public bool isInvincible = false;
    private bool isDying;
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
    public UnityEvent onHealReceived;
    public Slider healthSlider;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        invincibilityController = GetComponent<InvincibilityController>();
        health = GetComponent<IHealth>();
    }

    private void Start()
    {
        isDying = false;
        healthSlider.maxValue = health.GetMaxHealth();
        healthSlider.value = health.GetCurrentHealth();
    }

    public void DealDamage(float damageAmount)
    {
        if (!isInvincible && !playerController.IsShieldActive() && !isDying)
        {
            onDamageTaken.Invoke();
            health.ChangeHealth(damageAmount);
            healthSlider.value = health.GetCurrentHealth();
            CheckIfPlayerHasZeroHealth();
        }
    }
    private void CheckIfPlayerHasZeroHealth()
    {
        if (health.GetCurrentHealth() <= 0 && !isDying)
        {
            isDying = true;
            onHealthZero.Invoke();
        }
        else
        {
            invincibilityController.StartInvincibility(invincibilityDuration, flashColor, numberOfFlashes);
        }
    }

    public void HealObject(float healAmount)
    {
        if (healAmount > 0)
        {
            onHealReceived.Invoke();
            health.ChangeHealth(healAmount);
            healthSlider.value = health.GetCurrentHealth();
        }
        else
        {
            throw new System.Exception("Cannot deal positive damage to an object!");
        }
    }

    public bool IsAtMaxHP()
    {
        return health.GetCurrentHealth() == health.GetMaxHealth();
    }
}
