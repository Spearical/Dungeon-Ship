using UnityEngine;

public class Deflectable : MonoBehaviour
{
    public float deflectionDamageMultiplier;
    public float deflectionSizeMultiplier;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<DeflectionShield>
            (out DeflectionShield deflectionShield))
        {
            Destroy(collision.otherCollider.gameObject);
        }
    }
}
