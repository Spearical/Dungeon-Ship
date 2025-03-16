using UnityEngine;
using UnityEngine.Events;

public class EnemyProjectile : MonoBehaviour
{
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
        rigidBody.AddForce(transform.up * speed);
    }

    private void OnCollisionEnter2D()
    {
        onContactDestroy.Invoke();
    }
    public void Fire()
    {
        Destroy(gameObject, aliveTimer);
    }

    public void SetProjectileSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetProjectileSprite(Sprite sprite)
    {
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            spriteRenderer.sprite = sprite;
        }
    }
}
