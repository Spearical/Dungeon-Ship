using UnityEngine;

public class PickupHeal : MonoBehaviour
{
    public float playerHealAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryHealObject(collision.gameObject, playerHealAmount);
    }

    void TryHealObject(GameObject objectToHeal, float playerHealAmount)
    { 
        if (objectToHeal.TryGetComponent<IHealable>(out IHealable healableObject))
        {
            if (!healableObject.IsAtMaxHP())
            {
                healableObject.HealObject(playerHealAmount);
            }
        }
    }
}
