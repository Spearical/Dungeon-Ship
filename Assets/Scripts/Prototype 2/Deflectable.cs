using UnityEngine;

public class Deflectable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player Shield"))
        {
            Destroy(collision.otherCollider.gameObject);
        }
    }
}
