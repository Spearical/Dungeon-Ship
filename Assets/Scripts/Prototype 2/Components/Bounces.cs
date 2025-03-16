using UnityEngine;
using UnityEngine.Events;

public class Bounces : MonoBehaviour
{
    [SerializeField]
    private int bounces = 5;

    [SerializeField]
    private int bounceBoostAddingNumber = 3;
    public UnityEvent onBouncesZero;
    public UnityEvent onBouncesUpdated;

    private void Start()
    {
        onBouncesUpdated.Invoke();
    }

    public void DecreaseBounces()
    {
        bounces --;
        onBouncesUpdated.Invoke();
        if (bounces <= 0)
        {
            onBouncesZero.Invoke();
        }
    }

    public void AddToCurrentBounces(int addToBounces)
    {
        bounces += addToBounces;
        onBouncesUpdated.Invoke();
    }

    public void AddToCurrentBounces()
    {
        bounces += bounceBoostAddingNumber;
        onBouncesUpdated.Invoke();
    }

    public int GetCurrentBounces()
    {
        return bounces;
    }
}
