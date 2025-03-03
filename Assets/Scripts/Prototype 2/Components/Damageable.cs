using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour, IDamageable
{
    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void DealDamage(float damageAmount)
    {
        health.ChangeHealth(damageAmount);
    }
}
