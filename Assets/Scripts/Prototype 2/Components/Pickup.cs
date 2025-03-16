using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float fallSpeed = 2.0f;
    [SerializeField]
    public UnityEvent onPickupDestroy;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidBody.velocity = -transform.up * fallSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            onPickupDestroy.Invoke();
        }
    }
}
