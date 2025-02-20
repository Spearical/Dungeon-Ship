using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody { get; private set; } 
    [SerializeField]
    private float speed = 500.0f;
    private void Awake()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1.0f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1.0f, 1.0f);
        force.y = -1f;

        this.rigidBody.AddForce(force.normalized * this.speed);
    }
}
