using UnityEngine;

public class DeflectedProjectile : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float speed = 500.0f;
    [SerializeField]
    private float aliveTimer = 30.0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, aliveTimer);
        SetRandomTrajectory();
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1.0f, 1.0f);
        force.y = 1f;

        rigidBody.AddForce(force.normalized * speed);
    }
}
