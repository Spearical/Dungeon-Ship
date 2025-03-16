using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageController : MonoBehaviour, IDamageable
{
    public bool disableInvincibility;
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
    private bool isDying;
    private float timer;

    private void Awake()
    {
        health = GetComponent<IHealth>();
        invincibilityController = GetComponent<EnemyInvincibilityController>();
    }

    private void Start()
    {
        timer = 0;
        isDying = false;
    }

    private void OnEnable()
    {
        timer = 0;
        isDying = false;
    }

    private void Update()
    {
        if (isInvincible)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        if (timer >= invincibilityDuration && isInvincible)
        {
            isInvincible = false;
            timer = 0;
        }
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
        if (health.GetCurrentHealth() <= 0 && !isDying)
        {
            isDying = true;
            onHealthZero.Invoke();  
        }
        else
        {
            if (!disableInvincibility)
            {
                invincibilityController.StartInvincibility(invincibilityDuration, flashColor, numberOfFlashes);
            }
        }
    }
}
