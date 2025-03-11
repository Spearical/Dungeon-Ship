using UnityEngine;
using UnityEngine.Events;

public class BrickDamageController : MonoBehaviour, IDamageable
{
    public bool isUnbreakable;
    public UnityEvent OnHitEffect;
    private float maxHealth;
    private Health currentHealth;
    private BrickDamageVisual brickDamageVisual;

    void Awake()
    {
        currentHealth = GetComponent<Health>();
        brickDamageVisual = GetComponent<BrickDamageVisual>();
    }

    void Start()
    {
        maxHealth = currentHealth.GetHeatlth();
    }

    public void DealDamage(float damageAmount)
    {
        if (!isUnbreakable)
        {
            OnHitEffect.Invoke();
            currentHealth.ChangeHealth(damageAmount);
            brickDamageVisual.UpdateSpriteBasedOnHealthPercentage(currentHealth.GetHeatlth() / maxHealth);
        }
    }
}
