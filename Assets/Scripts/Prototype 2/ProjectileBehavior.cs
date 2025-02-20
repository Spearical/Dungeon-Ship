using UnityEngine;
using UnityEngine.Events;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float speed = 15.0f;
    [SerializeField]
    private float aliveTimer = 5.0f;
    public UnityEvent onContactDestroy;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(transform.up.normalized * speed);
    }

    private void OnCollisionEnter2D()
    {
        onContactDestroy.Invoke();
    }
    public void Fire()
    {
        Destroy(gameObject, aliveTimer);
    }
}
