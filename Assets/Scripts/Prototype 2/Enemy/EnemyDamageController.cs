using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class EnemyDamageController : MonoBehaviour, IDamageable
{
    private Health health;
    private EnemyBehavior enemyBehavior;
    public UnityEvent onHealthZero;
    public UnityEvent onDamageTaken;

    private void Awake()
    {
        enemyBehavior = GetComponent<EnemyBehavior>();
        health = GetComponent<Health>();
    }

    public void DealDamage(float damageAmount)
    {
        onDamageTaken.Invoke();
        health.ChangeHealth(damageAmount);
        CheckIfEnemyHasZeroHealth();
    }
    private void CheckIfEnemyHasZeroHealth()
    {
        if (health.GetHeatlth() <= 0)
        {
            onHealthZero.Invoke();
        }    
    }
}
