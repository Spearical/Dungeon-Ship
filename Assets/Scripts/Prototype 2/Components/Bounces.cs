using UnityEngine;
using UnityEngine.Events;

public class Bounces : MonoBehaviour
{
    [SerializeField]
    private int bounces = 5;

    [SerializeField]
    private int bounceBoostAddingNumber = 3;
    public UnityEvent onBouncesZero;

    public void DecreaseBounces()
    {
        bounces --;
        if (bounces <= 0)
        {
            onBouncesZero.Invoke();
        }
    }

    public void AddToCurrentBounces(int addToBounces)
    {
        bounces += addToBounces;
    }

    public void AddToCurrentBounces()
    {
        bounces += bounceBoostAddingNumber;
    }

    public float GetCurrentBounces()
    {
        return bounces;
    }
}
