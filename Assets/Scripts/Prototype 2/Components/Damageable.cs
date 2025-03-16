using UnityEngine;

[RequireComponent(typeof(IHealth))]
public class Damageable : MonoBehaviour, IDamageable
{
    IHealth health;

    private void Awake()
    {
        health = GetComponent<IHealth>();
    }

    public void DealDamage(float damageAmount)
    {
        if (damageAmount < 0)
        {
            health.ChangeHealth(damageAmount);
        }
        else
        {
            throw new System.Exception("Cannot deal positive damage to an object!");
        }
        
    }
}
