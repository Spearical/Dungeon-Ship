using UnityEngine;
using UnityEngine.Events;

public class Bounces : MonoBehaviour
{
    [SerializeField]
    private int bounces = 5;
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

    public float GetCurrentBounces()
    {
        return bounces;
    }
}
