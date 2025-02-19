using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float direction;
    [SerializeField]
    private float moveSpeed = 50f;
    [SerializeField]
    private float maxBounceAngle = 75f;

    private void Awake()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        this.rigidBody.AddForce(this.direction * transform.right * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point; // Only care about first point of contact
            
            float offset = paddlePosition.x - contactPoint.x;
            float width =  collision.otherCollider.bounds.size.x / 2; // Half width of paddle

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidBody.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidBody.velocity = rotation * Vector2.up * ball.rigidBody.velocity.magnitude;
        }
    }
}
