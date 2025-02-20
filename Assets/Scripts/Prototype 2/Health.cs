using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    public UnityEvent onHealthZero;

    public void ChangeHealth(float amountToChange)
    {
        health += amountToChange;
        if (health <= 0)
        {
            onHealthZero.Invoke();
        }
    }
}
