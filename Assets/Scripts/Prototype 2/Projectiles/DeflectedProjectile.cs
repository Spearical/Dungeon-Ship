using UnityEngine;

[RequireComponent(typeof(Bounces))]
public class DeflectedProjectile : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float speed = 500.0f;
    [SerializeField]
    private float aliveTimer = 30.0f;
    private Bounces bounces;

    private void Awake()
    {
        bounces = GetComponent<Bounces>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, aliveTimer);
        SetRandomTrajectory();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.TryGetComponent<BrickDamageController>
            (out BrickDamageController brickDamageController))
        {
            // Only want to reduce bounces if the brick is damageable!
            if (!brickDamageController.isUnbreakable)
            {
                bounces.DecreaseBounces();
            }
        }
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1.0f, 1.0f);
        force.y = 1f;

        rigidBody.AddForce(force.normalized * speed);
    }
}
