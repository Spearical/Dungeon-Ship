using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class Healable : MonoBehaviour, IHealable
{
    IHealth health;
    private void Awake()
    {
        health = GetComponent<IHealth>();
    }

    public void HealObject(float healAmount)
    {
        if (healAmount > 0)
        {
            health.ChangeHealth(healAmount);
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
