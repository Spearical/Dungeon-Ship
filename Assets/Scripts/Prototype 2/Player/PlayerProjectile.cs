using UnityEngine;
using UnityEngine.Events;

public class PlayerProjectile : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float speed = 600.0f;
    [SerializeField]
    private float aliveTimer = 5.0f;
    public UnityEvent onContactDestroy;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidBody.velocity =  Vector2.up * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
