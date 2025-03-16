using UnityEngine;

public class MoveSideToSide : MonoBehaviour, IMovement
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float moveSpeed = 250f;
    private int direction;
    [SerializeField]
    private const int DETECTION_RANGE_SCALAR = 3;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        direction = (int)Mathf.Sign(Random.Range(-1, 2)); // -1 for negative, 1 for positive
    }

    public void Move()
    {
        rigidBody.AddForce(new Vector2(direction, 0f) * moveSpeed * Time.fixedDeltaTime);
        DetectIncomingWall();
    }

    private void DetectIncomingWall()
    {
        RaycastHit2D leftRay = Physics2D.Raycast(transform.position, Vector2.left, DETECTION_RANGE_SCALAR);
        RaycastHit2D rightRay = Physics2D.Raycast(transform.position, -Vector2.left, DETECTION_RANGE_SCALAR);

        if (leftRay.collider != null 
        && (leftRay.collider.CompareTag("Wall") || leftRay.collider.CompareTag("Enemy") || leftRay.collider.CompareTag("Brick") || leftRay.collider.CompareTag("Unbreakable Brick")))
        {
            direction = 1;
        } 
        
        if (rightRay.collider != null 
        && (rightRay.collider.CompareTag("Wall") || rightRay.collider.CompareTag("Enemy") || rightRay.collider.CompareTag("Brick") || rightRay.collider.CompareTag("Unbreakable Brick")))
        {
            direction = -1;
        } 
    }
}
