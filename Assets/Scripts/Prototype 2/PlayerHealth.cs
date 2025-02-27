using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;


    public void ChangePlayerHealth(float amountToChange)
    {
        health += amountToChange;
    }

    public float GetCurrentPlayerHealth()
    {
        return health;
    }
}
