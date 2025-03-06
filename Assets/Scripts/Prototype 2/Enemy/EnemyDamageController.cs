using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageController : MonoBehaviour, IDamageable
{
    private IHealth health;
    public UnityEvent onHealthZero;
    public UnityEvent onDamageTaken;

    private void Awake()
    {
        health = GetComponent<IHealth>();
    }

    public void DealDamage(float damageAmount)
    {
        onDamageTaken.Invoke();
        health.ChangeHealth(damageAmount);
        CheckIfEnemyHasZeroHealth();
    }
    private void CheckIfEnemyHasZeroHealth()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            onHealthZero.Invoke();  
        }    
    }
}
